using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Root.Scripts.UI.Screens
{
    public class ScreensController : MonoBehaviour
    {
        [SerializeField] private ScreensData screensData = default;

        private const int FirstScreen = 0;
        
        private Transform _tr;
        
        private ScreensData _screensData;
        
        private List<BaseScreen> _screens = new List<BaseScreen>();

        public void Init()
        {
            _tr = transform;
            
            _screensData = screensData;
            
            CreateScreens();
            
            DeactivateAllScreens();
            
            if (_screens.Count > 0)
            {
                _screens.ElementAt(FirstScreen).Activate();
            }
        }
        
        public void ActivateCertainScreen(ScreenType screenType)
        {
            BaseScreen screen = GetScreenByType(screenType);
            
            DeactivateAllScreens();
            screen.Activate();
        }

        private void CreateScreens()
        {
            foreach (var screenData in _screensData.List)
            {
                BaseScreen screen = Instantiate(screenData.Prefab, _tr).GetComponent<BaseScreen>();
                screen.Init(screenData.ScreenType);
                
                _screens.Add(screen);
            }
        }

        private BaseScreen GetScreenByType(ScreenType screenType)
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenType == screenType) return screen;
            }

            return null;
        }

        private void DeactivateAllScreens()
        {
            foreach (var screen in _screens)
            {
                screen.Deactivate();
            }
        }
    }
}
