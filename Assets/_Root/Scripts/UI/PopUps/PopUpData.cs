using UnityEngine;

namespace _Root.Scripts.UI.PopUps
{
    [CreateAssetMenu(fileName = "Pop Up", menuName = "Data/UI/Pop Ups/Pop Up")]
    public class PopUpData : ScriptableObject
    {
        [SerializeField] private PopUpType popUpType = default;
        [SerializeField] private GameObject prefab = default;

        public PopUpType PopUpType => popUpType;
        public GameObject Prefab => prefab;
    }

    // Add new value to enum when create new type of pop up
    public enum PopUpType
    {
        Undefined = 0
    }
}
