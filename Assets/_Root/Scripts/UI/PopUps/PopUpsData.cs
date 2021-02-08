using System.Collections.Generic;
using UnityEngine;

namespace _Root.Scripts.UI.PopUps
{
    [CreateAssetMenu(fileName = "Pop Ups", menuName = "Data/UI/Pop Ups/List")]
    public class PopUpsData : ScriptableObject
    {
        [SerializeField] private List<PopUpData> list = new List<PopUpData>();

        public List<PopUpData> List => list;
    }
}
