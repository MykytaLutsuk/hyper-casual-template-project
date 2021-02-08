using UnityEngine;

namespace _Root.Scripts.UI.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject root = default;

        private ScreenType _screenType;
        
        private bool _isActive;

        public ScreenType ScreenType => _screenType;
        public bool IsActive => _isActive;

        public void Init(ScreenType screenType)
        {
            _screenType = screenType;
        }

        public void Activate()
        {
            _isActive = true;
            
            Show();
        }

        public void Deactivate()
        {
            _isActive = false;
            
            Hide();
        }

        protected virtual void Show()
        {
            root.SetActive(true);
        }

        protected virtual void Hide()
        {
            root.SetActive(false);
        }
    }
}
