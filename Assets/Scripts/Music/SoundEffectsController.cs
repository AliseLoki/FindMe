using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsController : MonoBehaviour
{
    private const string PlayerPrefsSoundEffectsVolume = nameof(PlayerPrefsSoundEffectsVolume);

    [SerializeField] private List<AudioSource> _allSoundEffectsAudioSources;

    [SerializeField] private Slider _slider;

    private float _defaultSoundEffectVolumeValue = 0.5f;

    private void Awake()
    {
        _slider.value = PlayerPrefs.GetFloat(PlayerPrefsSoundEffectsVolume, _defaultSoundEffectVolumeValue);
        ChangeVolumeForAllSoundEffectsAudioSources();
    }

    public void ChangeSoundEffectsVolume()
    {
        ChangeVolumeForAllSoundEffectsAudioSources();
        PlayerPrefs.SetFloat(PlayerPrefsSoundEffectsVolume, _slider.value);
        PlayerPrefs.Save();
    }

    private void ChangeVolumeForAllSoundEffectsAudioSources()
    {
        foreach (var audioSource in _allSoundEffectsAudioSources)
        {
            audioSource.volume = _slider.value;
        }
    }
}
