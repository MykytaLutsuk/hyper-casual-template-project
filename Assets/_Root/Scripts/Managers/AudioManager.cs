using System.Collections.Generic;
using _Root.Scripts.Audio;
using Plugins.Singletons;
using Plugins.zPooling;
using UnityEngine;

namespace _Root.Scripts.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioListener audioListener = default;

        [SerializeField] private GameObject musicPrefab = default;
        [SerializeField] private GameObject sfxPrefab = default;
        
        private List<Music> _musics = new List<Music>();

        public void PlayMusic(SoundData soundData)
        {
            Music music = musicPrefab.Pool<Music>();
            music.name = $"Music: {soundData.Clip.name}";
            
            music.Play(soundData);

            _musics.Add(music);
        }

        public void PlaySfx(SoundData soundData)
        {
            Sfx sfx = sfxPrefab.Pool<Sfx>();
            sfx.name = $"Sfx: {soundData.Clip.name}";

            sfx.Play(soundData);
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void MuteAudio(bool mute)
        {
            audioListener.enabled = !mute;
        }

        private void RemoveAllMusic()
        {
            foreach (var music in _musics)
            {
                music.Decommission();
            }
            
            _musics.Clear();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            audioListener = GetComponent<AudioListener>();
        }
#endif
    }
}
