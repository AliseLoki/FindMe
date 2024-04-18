using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CanvasUIButtonsController : MonoBehaviour
{
    public AudioMixerGroup AudioMixer;

    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
    public void OnCameraViewChangeButtonPressed()
    {
        ShowOrHideObject(_cameraSlider.gameObject);
    }

    public void OnMusicVolumeChangeButtonPressed()
    {
        ShowOrHideObject(_musicVolumeSlider.gameObject);
    }

    public void OnSoundEffectsVolumeChangeButtonPressed()
    {
        ShowOrHideObject(_soundEffectsVolumeSlider.gameObject);
    }

    private void ShowOrHideObject(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
