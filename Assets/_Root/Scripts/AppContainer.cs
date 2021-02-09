using _Root.Scripts.Managers;
using _Root.Scripts.Singletons;
using UnityEngine;

namespace _Root.Scripts
{
    public class AppContainer : Singleton<AppContainer>
    {
        [SerializeField] private GameManager gameManager = default;
        [SerializeField] private UiManager uiManager = default;
        [SerializeField] private SettingsManager settingsManager = default;
        
        public GameManager GameManager => gameManager;
        public UiManager UiManager => uiManager;
        public SettingsManager SettingsManager => settingsManager;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void Start()
        {
            uiManager.Init();
            gameManager.Init();
            settingsManager.Init();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (uiManager == null) uiManager = FindObjectOfType<UiManager>();
            if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
            if (settingsManager == null) settingsManager = FindObjectOfType<SettingsManager>();
        }
#endif
    }
}
