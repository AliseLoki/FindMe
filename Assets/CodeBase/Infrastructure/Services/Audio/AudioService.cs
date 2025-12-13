using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Audio
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _defaultClip;

        private AudioClip _currentClip;

        public AudioClip DefaultClip => _defaultClip;

        public void PlayBackgroundMusic(AudioClip clip)
        {
            if (_currentClip == clip) return;

            _audioSource.clip = clip;
            _audioSource.Play();
            _currentClip = clip;
        }
    }
}
