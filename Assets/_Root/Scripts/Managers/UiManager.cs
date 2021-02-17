using _Root.Scripts.UI.PopUps;
using _Root.Scripts.UI.Screens;
using Plugins.Singletons;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private ScreensController screensController = default;
        [SerializeField] private PopUpsController popUpsController = default;

        public ScreensController ScreensController => screensController;
        public PopUpsController PopUpsController => popUpsController;

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
            screensController.Init();
            popUpsController.Init();
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
