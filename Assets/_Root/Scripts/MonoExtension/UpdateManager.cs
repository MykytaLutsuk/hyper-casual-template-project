using System.Linq;
using UnityEngine;

namespace _Root.Scripts.MonoExtension
{
    public class UpdateManager : MonoBehaviour
    {
        private void Update()
        {
            for (int i = 0; i < MonoCached.AllCustomUpdate.Count; i++)
            {
                MonoCached.AllCustomUpdate.ElementAt(i).CustomUpdate();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < MonoCached.AllCustomFixedUpdate.Count; i++)
            {
                MonoCached.AllCustomUpdate.ElementAt(i).CustomFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < MonoCached.AllCustomLateUpdate.Count; i++)
            {
                MonoCached.AllCustomUpdate.ElementAt(i).CustomLateUpdate();
            }
        }
    }
}
