using System.Collections.Generic;
using UnityEngine;

namespace _Root.Scripts.UI.Screens
{
    [CreateAssetMenu(fileName = "Screens", menuName = "Data/UI/Screens/List")]
    public class ScreensData : ScriptableObject
    {
        [SerializeField] private List<ScreenData> list = new List<ScreenData>();
        
        public List<ScreenData> List => list;
    }
}
