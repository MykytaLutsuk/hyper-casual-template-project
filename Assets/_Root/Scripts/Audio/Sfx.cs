using System.Collections;
using UnityEngine;

namespace _Root.Scripts.Audio
{
    public class Sfx : MonoBehaviour
    {
        [SerializeField] private SfxData sfxData = default;

        private SfxData _sfxData;
        
        public void Play()
        {
            _sfxData = sfxData;

            StartCoroutine(PlayCor());
        }

        private IEnumerator PlayCor()
        {
            GameObject sfx = new GameObject{name = $"Sfx - {sfxData.id}"};
            AudioSource audioSource = sfx.AddComponent<AudioSource>();
            audioSource.clip = _sfxData.clip;
            audioSource.playOnAwake = false;
            audioSource.Play();

            float duration = _sfxData.clip.length;
            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return null;
            }
            
            Destroy(sfx);
        }
    }
}
