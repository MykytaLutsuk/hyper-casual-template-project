using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Root.Scripts.Services
{
    public class ServicesInitializer : MonoBehaviour
    {
        [SerializeField] private List<BaseService> services = new List<BaseService>();
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (var service in services)
            {
                service.Init();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            services = GetComponentsInChildren<BaseService>().ToList();
        }
#endif
    }
}
