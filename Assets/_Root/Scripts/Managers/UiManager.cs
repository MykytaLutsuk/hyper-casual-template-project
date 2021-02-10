using _Root.Scripts.UI.PopUps;
using _Root.Scripts.UI.Screens;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private ScreensController screensController = default;
        [SerializeField] private PopUpsController popUpsController = default;

        public ScreensController ScreensController => screensController;
        public PopUpsController PopUpsController => popUpsController;

        public void Init()
        {
            screensController.Init();
            popUpsController.Init();
            
            Debug.Log($"Ui Manager initialized!");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (screensController == null) screensController = FindObjectOfType<ScreensController>();
            if (popUpsController == null) popUpsController = FindObjectOfType<PopUpsController>();
        }
#endif
    }
}
