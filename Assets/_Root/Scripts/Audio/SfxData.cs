using UnityEngine;

namespace _Root.Scripts.Audio
{
    [CreateAssetMenu(fileName = "Sfx", menuName = "Data/Sounds/Sfx")]
    public class SfxData : ScriptableObject
    {
        public string id;
        public AudioClip clip;
    }
}
