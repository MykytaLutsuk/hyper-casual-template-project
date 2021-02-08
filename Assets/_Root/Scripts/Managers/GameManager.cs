using _Root.Scripts.Singletons;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private UiManager uiManager = default;

        protected override void Awake()
        {
            base.Awake();
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
