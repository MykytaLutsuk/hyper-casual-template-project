using _Root.Scripts.Data;
using UnityEditor;
using UnityEngine;

namespace _Root.Scripts.Editor
{
    public class Tools
    {
        [MenuItem("Tools/Clear player data")]
        public static void ClearPlayerData()
        {
            PlayerProfile.ClearPlayerData();
            Debug.Log($"Player data are cleared...");
        }
    }
}
