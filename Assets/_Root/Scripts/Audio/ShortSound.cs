using UnityEngine;

namespace _Root.Scripts.Audio
{
    public class ShortSound : BaseSound
    {
        public void Play()
        {
            AudioSource audioSource = CreateAudioSource();
            ConfigureAudioSource(audioSource);

            audioSource.loop = false;

            Destroy(audioSource.gameObject, SoundData.clip.length);
        }
    }
}
