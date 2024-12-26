using SaveSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundSystem
{
    public class SoundEffectsController : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Saver _saver;
        [SerializeField] private List<AudioSource> _allSoundEffectsAudioSources;

        private void Awake()
        {
            _slider.value = _saver.LoadSoundEffectVolume();
            ChangeVolumeForAllSoundEffectsAudioSources();
        }

        public void ChangeSoundEffectsVolume()
        {
            ChangeVolumeForAllSoundEffectsAudioSources();
            _saver.SaveSoundEffectVolume(_slider.value);
        }

        private void ChangeVolumeForAllSoundEffectsAudioSources()
        {
            foreach (var audioSource in _allSoundEffectsAudioSources)
            {
                audioSource.volume = _slider.value;
            }
        }
    }
}
