using System.Collections.Generic;
using _Root.Scripts.MonoExtension;
using UnityEngine;

namespace _Root.Scripts.UI.PopUps
{
    public class PopUpsController : MonoCached
    {
        [SerializeField] private PopUpsData popUpsData = default;
        
        private Transform _tr;

        private PopUpsData _popUpsData;
        
        private List<BasePopUp> _popUps = new List<BasePopUp>();
        
        public void Init()
        {
            _tr = transform;

            _popUpsData = popUpsData;
            
            CreatePopUps();
            
            DeactivateAllPopUps();
        }

        public void ActivateCertainPopUp(PopUpType popUpType)
        {
            BasePopUp popUp = GetPopUpByType(popUpType);
            
            popUp.Activate();
        }
        
        private void CreatePopUps()
        {
            foreach (var popUpData in _popUpsData.List)
            {
                BasePopUp popUp = Instantiate(popUpData.Prefab, _tr).GetComponent<BasePopUp>();
                popUp.Init(popUpData.PopUpType);

                _popUps.Add(popUp);
            }
        }
        
        private BasePopUp GetPopUpByType(PopUpType popUpType)
        {
            foreach (var popUp in _popUps)
            {
                if (popUp.PopUpType == popUpType) return popUp;
            }

            return null;
        }
        
        private void DeactivateAllPopUps()
        {
            foreach (var popUp in _popUps)
            {
                popUp.Deactivate();
            }
        }
    }
}
