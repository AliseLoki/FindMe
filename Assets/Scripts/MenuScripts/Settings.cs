using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    private const string masterVolume = nameof(masterVolume);

    [SerializeField] private AudioMixer _audioMixer;

    public void ChangeAudioVolume(float sliderValue)
    {
        _audioMixer.SetFloat(masterVolume, sliderValue);
    }
}
