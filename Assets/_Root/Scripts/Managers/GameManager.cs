using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UiManager uiManager = default;
        
        private void Awake()
        {
            // TODO: Load services and etc.
        }

        private void Start()
        {
            uiManager.Init();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (uiManager == null) uiManager = FindObjectOfType<UiManager>();
        }
#endif
    }
}
