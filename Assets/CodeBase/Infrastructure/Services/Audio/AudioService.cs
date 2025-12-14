using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Audio
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgMusicSource;
        [SerializeField] private AudioSource _effectsSource;
        [SerializeField] private AudioClip _defaultClip;

        private AudioClip _currentClip;

        public AudioClip DefaultClip => _defaultClip;

        public void PlayEffect(AudioClip clip)
        {
            _effectsSource.PlayOneShot(clip);
        }

        public void PlayBackgroundMusic(AudioClip clip)
        {
            if (_currentClip == clip) return;

            _bgMusicSource.clip = clip;
            _bgMusicSource.Play();
            _currentClip = clip;
        }
    }
}
