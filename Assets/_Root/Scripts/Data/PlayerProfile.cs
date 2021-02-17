using Plugins.Singletons;
using UnityEngine;

namespace _Root.Scripts.Data
{
    public class PlayerProfile : Singleton<PlayerProfile>
    {
        public PlayerData PlayerData => _playerData;
        private PlayerData _playerData;

        private DataSerialization _dataSerialization;

        // Serializing data object to Json - string.
        public void SavePlayerData()
        {
            var serializedData = JsonUtility.ToJson(_playerData);
            
            _dataSerialization.Save(serializedData);
        }

        // Deserialization of string into data object again.
        public void LoadPlayerData()
        {
            string json = _dataSerialization.Load();

            var deserializedData = JsonUtility.FromJson<PlayerData>(json);

            _playerData = deserializedData ?? new PlayerData();
        }

        public void ClearPlayerData()
        {
            _dataSerialization.Clear();
        }

        protected override void Awake()
        {
            base.Awake();

            Initialize();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void Initialize()
        {
            // Can choose realization of serialization data
            _dataSerialization = new PlayerPrefsSerialization();
            
            LoadPlayerData();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) SavePlayerData();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) SavePlayerData();
        }
    }
}
