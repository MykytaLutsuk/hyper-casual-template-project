using UnityEngine;

namespace _Root.Scripts.Utility
{
    public class DebugSwitcher : MonoBehaviour
    {
        private void Awake()
        {
            Debug.unityLogger.logEnabled = Debug.isDebugBuild;
        }
    }
}
