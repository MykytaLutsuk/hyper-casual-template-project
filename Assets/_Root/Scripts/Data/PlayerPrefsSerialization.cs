using UnityEngine;

namespace _Root.Scripts.Data
{
    public class PlayerPrefsSerialization : DataSerialization
    {
        private const string KeyToData = "0123456789";
        
        public override void Save(string json)
        {
            PlayerPrefs.SetString(KeyToData, json);
        }

        public override string Load()
        {
            if (PlayerPrefs.HasKey(KeyToData))
            {
                return PlayerPrefs.GetString(KeyToData);
            }
        
            Debug.LogErrorFormat("There is no data in PlayerPrefs under key: {0}", KeyToData);
            
            return "";
        }

        public override void Clear()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
