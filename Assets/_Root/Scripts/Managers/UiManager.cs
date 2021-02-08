using _Root.Scripts.UI.Screens;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private ScreensController screensController = default;

        public ScreensController ScreensController => screensController;

        public void Init()
        {
            screensController.Init();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (screensController == null) screensController = GetComponentInChildren<ScreensController>();
        }
#endif
    }
}
