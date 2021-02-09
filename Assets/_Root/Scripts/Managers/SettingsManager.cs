using _Root.Scripts.Settings;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private GameSettingsData gameSettingsData = default;
        [SerializeField] private MonetizationSettingsData monetizationSettingsData = default;
        [SerializeField] private UiSettingsData uiSettingsData = default;
        
        public GameSettingsData GameSettingsData => gameSettingsData;
        public MonetizationSettingsData MonetizationSettingsData => monetizationSettingsData;
        public UiSettingsData UiSettingsData => uiSettingsData;

        public void Init()
        {
        }
    }
}
