using _Root.Scripts.Singletons;
using UnityEngine;

namespace _Root.Scripts.Settings
{
    public class GlobalSettings : PersistentSingleton<GlobalSettings>
    {
        [SerializeField] private GameSettingsData gameSettingsData = default;
        [SerializeField] private MonetizationSettingsData monetizationSettingsData = default;
        [SerializeField] private UiSettingsData uiSettingsData = default;
        
        public GameSettingsData GameSettingsData => gameSettingsData;
        public MonetizationSettingsData MonetizationSettingsData => monetizationSettingsData;
        public UiSettingsData UiSettingsData => uiSettingsData;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
