using PlayerController;
using SaveSystem;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace SoundSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class Music : MonoBehaviour
    {
        [SerializeField] private MusicSO _musicSO;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Player _player;
        [SerializeField] private Saver _saver;

        private bool _isForestMusicPlaying;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _musicVolumeSlider.value = _saver.LoadMusicVolume();
            ChangeVolume();
            PlayStartMusic();
        }

        private void OnEnable()
        {
            _player.PlayerHealth.PlayerHasDied += PlayGameOverMusic;
        }

        private void OnDisable()
        {
            _player.PlayerHealth.PlayerHasDied -= PlayGameOverMusic;
        }

        public void ChangeMusicVolume()
        {
            ChangeVolume();
            _saver.SaveMusicVolume(_musicVolumeSlider.value);
        }

        public void PlayWitchAppearMusic()
        {
            PlayMusic(_musicSO.WitchAppearMusic);
        }

        private void ChangeVolume()
        {
            _audioSource.volume = _musicVolumeSlider.value;
        }

        public void PlayForestMusic()
        {
            if (!_isForestMusicPlaying)
            {
                PlayMusic(_musicSO.ForestMusic);
                _isForestMusicPlaying = true;
            }
        }

        public void PlayRoadMusic()
        {
            PlayMusic(_musicSO.RoadMusic);
        }

        public void PlayStartMusic()
        {
            PlayMusic(_musicSO.StartMusic);
        }

        public void PlayGameOverMusic()
        {
            PlayMusic(_musicSO.GameOverMusic);
        }

        public void PlayMusic(AudioClip audioClip)
        {
            _audioSource.Stop();
            _audioSource.clip = audioClip;
            _audioSource.Play();
            _isForestMusicPlaying = false;
        }
    }
}