using System.Collections;
using System.Collections.Generic;
using _Root.Scripts.Sounds;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class SoundsManager : MonoBehaviour
    {
        private List<AudioSource> _audioSources = new List<AudioSource>();
        
        public void Init()
        {
            Debug.Log($"Sounds Manager initialized!");
        }

        public void PlayMusic(SoundData soundData)
        {
            GameObject soundObj = new GameObject {name = $"Music: {soundData.Clip.name}"};
            AudioSource audioSource = soundObj.AddComponent<AudioSource>();

            audioSource.clip = soundData.ChooseRandomClip ? soundData.RandomClip : soundData.Clip;
            
            audioSource.bypassEffects = soundData.ByPassEffects;
            audioSource.bypassListenerEffects = soundData.ByPassListenerEffects;
            audioSource.bypassReverbZones = soundData.ByPassReverbZones;
            audioSource.priority = soundData.Priority;
            audioSource.volume = soundData.Volume;
            audioSource.pitch = soundData.Pitch;
            audioSource.panStereo = soundData.StereoPan;
            audioSource.spatialBlend = soundData.SpatialBlend;
            audioSource.reverbZoneMix = soundData.ReverbZoneMix;
            
            audioSource.playOnAwake = false;
            audioSource.loop = true;
            
            audioSource.Play();
            
            _audioSources.Add(audioSource);
        }

        public void PlaySfx(SoundData soundData)
        {
            GameObject soundObj = new GameObject {name = $"Sfx: {soundData.Clip.name}"};
            AudioSource audioSource = soundObj.AddComponent<AudioSource>();

            audioSource.clip = soundData.ChooseRandomClip ? soundData.RandomClip : soundData.Clip;

            audioSource.bypassEffects = soundData.ByPassEffects;
            audioSource.bypassListenerEffects = soundData.ByPassListenerEffects;
            audioSource.bypassReverbZones = soundData.ByPassReverbZones;
            audioSource.priority = soundData.Priority;
            audioSource.volume = soundData.Volume;
            audioSource.pitch = soundData.Pitch;
            audioSource.panStereo = soundData.StereoPan;
            audioSource.spatialBlend = soundData.SpatialBlend;
            audioSource.reverbZoneMix = soundData.ReverbZoneMix;
            
            audioSource.playOnAwake = false;
            audioSource.loop = false;

            StartCoroutine(PlaySfxCor(audioSource));
        }

        private IEnumerator PlaySfxCor(AudioSource audioSource)
        {
            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
            
            Destroy(audioSource.gameObject);
        }

        private void RemoveAllMusic()
        {
            foreach (var audioSource in _audioSources)
            {
                Destroy(audioSource.gameObject);
            }
            
            _audioSources.Clear();
        }
    }
}
