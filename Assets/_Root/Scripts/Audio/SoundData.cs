using UnityEngine;

namespace _Root.Scripts.Audio
{
    [CreateAssetMenu(fileName = "Sound", menuName = "Data/Sounds/Sound")]
    public class SoundData : ScriptableObject
    {
        public string id;
        public AudioClip clip;
        public bool playOnAwake;
    }
}
