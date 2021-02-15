using UnityEngine;

namespace _Root.Scripts.UI.PopUps
{
    public class BasePopUp : MonoBehaviour
    {
        [SerializeField] private GameObject root = default;

        private bool _isActive;

        private PopUpType _popUpType;
        
        public bool IsActive => _isActive;

        public PopUpType PopUpType => _popUpType;

        public void Init(PopUpType popUpType)
        {
            _popUpType = popUpType;
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
