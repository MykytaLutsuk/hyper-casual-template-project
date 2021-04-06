using UnityEngine;

namespace _Root.Scripts.Audio
{
    public class LongSound : BaseSound
    {
        private AudioSource _audioSource;
        
        public void Play()
        {
            if (_audioSource != null)
            {
                Destroy(_audioSource.gameObject);
                _audioSource = null;
            }
            
            _audioSource = CreateAudioSource();
            ConfigureAudioSource(_audioSource);

            _audioSource.loop = true;
            
            _audioSource.Play();
        }

        public void Stop()
        {
            if (_audioSource == null) return;
            
            _audioSource.Stop();
        }

        public void Pause()
        {
            if (_audioSource == null) return;
            
            _audioSource.Pause();
        }

        public void UnPause()
        {
            if (_audioSource == null) return;
            
            _audioSource.UnPause();
        }
    }
}
