using UnityEngine;

namespace _Root.Scripts.Audio
{
    public abstract class BaseSound : MonoBehaviour
    {
        [SerializeField] private SoundData soundData = default;

        protected SoundData SoundData => soundData;

        protected AudioSource CreateAudioSource()
        {
            GameObject go = new GameObject {name = $"{SoundData.id}"};
            return go.AddComponent<AudioSource>();
        }

        protected void ConfigureAudioSource(AudioSource audioSource)
        {
            audioSource.playOnAwake = SoundData.playOnAwake;
            audioSource.clip = SoundData.clip;
        }
    }
}
