using UnityEngine;

namespace _Root.Scripts.Data
{
    public class PlayerProfile : MonoBehaviour
    {
        public static PlayerData PlayerData => _playerData;
        private static PlayerData _playerData;

        private static DataSerialization _dataSerialization;

        // Serializing data object to Json - string.
        public static void SavePlayerData()
        {
            var serializedData = JsonUtility.ToJson(_playerData);
            
            _dataSerialization.Save(serializedData);
        }

        // Deserialization of string into data object again.
        public static void LoadPlayerData()
        {
            string json = _dataSerialization.Load();

            var deserializedData = JsonUtility.FromJson<PlayerData>(json);

            _playerData = deserializedData ?? new PlayerData();
        }

        public static void ClearPlayerData()
        {
            _dataSerialization.Clear();
        }
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            Initialize();
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
