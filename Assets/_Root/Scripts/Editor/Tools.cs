using _Root.Scripts.Data;
using UnityEditor;
using UnityEngine;

namespace _Root.Scripts.Editor
{
    public class Tools
    {
        private const string PathToBootScene = "Assets/_Root/Scenes/Boot Scene.unity";
        
        [MenuItem("Tools/Play")]
        public static void RunMainScene()
        {
            EditorApplication.OpenScene(PathToBootScene);
            EditorApplication.isPlaying = true;
        }
        
        [MenuItem("Tools/Clear player data")]
        public static void ClearPlayerData()
        {
            PlayerProfile.Instance.ClearPlayerData();
            Debug.Log($"Player data are cleared...");
        }
    }
}
