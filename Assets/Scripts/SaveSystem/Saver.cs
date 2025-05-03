using UnityEngine;

namespace SaveSystem
{
    public class Saver : MonoBehaviour
    {
        private const string CameraZoomValue = nameof(CameraZoomValue);
        private const string MusicVolume = nameof(MusicVolume);
        private const string SoundEffectsVolume = nameof(SoundEffectsVolume);

        private float _defaultCameraZoomValue = 30f;
        private float _defaultMusicVolume = 0.3f;
        private float _defaultSoundEffectsVolume = 0.5f;

        public float LoadCameraValue()
        {
            return PlayerPrefs.GetFloat(CameraZoomValue, _defaultCameraZoomValue);
        }

        public void SaveCameraValue(float cameraSliderValue)
        {
            PlayerPrefs.SetFloat(CameraZoomValue, cameraSliderValue);
        }

        public float LoadMusicVolume()
        {
            return PlayerPrefs.GetFloat(MusicVolume, _defaultMusicVolume);
        }

        public void SaveMusicVolume(float musicVolume)
        {
            PlayerPrefs.SetFloat(MusicVolume, musicVolume);
        }

        public float LoadSoundEffectVolume()
        {
            return PlayerPrefs.GetFloat(SoundEffectsVolume, _defaultSoundEffectsVolume);
        }

        public void SaveSoundEffectVolume(float soundEffectsVolume)
        {
            PlayerPrefs.SetFloat(SoundEffectsVolume, soundEffectsVolume);
        }
    }
}