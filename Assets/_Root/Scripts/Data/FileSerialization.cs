using System.IO;
using UnityEngine;

namespace _Root.Scripts.Data
{
    public class FileSerialization : DataSerialization
    {
        private const string PathToData = "";
        
        public override void Save(string json)
        {
            var filePath = Path.Combine(Application.persistentDataPath, PathToData);
        
            File.WriteAllText(PathToData, json);
        }

        public override string Load()
        {
            var filePath = Path.Combine(Application.persistentDataPath, PathToData);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        
            Debug.LogErrorFormat("There is no file under path: {0}", filePath);
            
            return "";
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
