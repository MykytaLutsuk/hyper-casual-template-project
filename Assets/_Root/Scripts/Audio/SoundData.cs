using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Root.Scripts.Audio
{
    [CreateAssetMenu(fileName = "Sound", menuName = "Data/Sounds/Sound")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private bool chooseRandomClip = default;
        [SerializeField] private AudioClip clip = default;
        [SerializeField] private List<AudioClip> clips = default;
        [SerializeField] private bool byPassEffects = default;
        [SerializeField] private bool byPassListenerEffects = default;
        [SerializeField] private bool byPassReverbZones = default;
        [Range(0, 256)] [SerializeField] private int priority = 128;
        [Range(0f, 1f)] [SerializeField] private float volume = 1f;
        [Range(-3f, 3f)] [SerializeField] private float pitch = 1f;
        [Range(-1f, 1f)] [SerializeField] private float stereoPan = 0f;
        [Range(0f, 1f)] [SerializeField] private float spatialBlend = 0f;
        [Range(0f, 1.1f)] [SerializeField] private float reverbZoneMix = 1f;

        public bool ChooseRandomClip => chooseRandomClip;
        public AudioClip Clip => clip;
        public AudioClip RandomClip => clips.ElementAt(Random.Range(0, clips.Count));
        public bool ByPassEffects => byPassEffects;
        public bool ByPassListenerEffects => byPassListenerEffects;
        public bool ByPassReverbZones => byPassReverbZones;
        public int Priority => priority;
        public float Volume => volume;
        public float Pitch => pitch;
        public float StereoPan => stereoPan;
        public float SpatialBlend => spatialBlend;
        public float ReverbZoneMix => reverbZoneMix;
    }
}
