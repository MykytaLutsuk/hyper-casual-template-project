using UnityEngine;

namespace _Root.Scripts.UI.Screens
{
    [CreateAssetMenu(fileName = "Screen", menuName = "Data/UI/Screens/Screen")]
    public class ScreenData : ScriptableObject
    {
        [SerializeField] private ScreenType screenType = default;
        [SerializeField] private GameObject prefab = default;

        public ScreenType ScreenType => screenType;
        public GameObject Prefab => prefab;
    }
    
    // Add new value to enum when create new type of screen
    public enum ScreenType
    {
        Undefined = 0,
        MainMenu = 1
    }
}
