using _Root.Scripts.MonoExtension;
using UnityEngine;

namespace _Root.Scripts.Utility
{
    public class DebugSwitcher : MonoCached
    {
        private void Awake()
        {
            Debug.unityLogger.logEnabled = Debug.isDebugBuild;
        }
    }
}
