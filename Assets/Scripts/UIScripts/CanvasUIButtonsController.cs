using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasUI))]
public class CanvasUIButtonsController : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;

    [SerializeField] private Button _firstStartPanelViewButton;
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;

    private CanvasUI _canvasUI;

    private void Awake()
    {
        _canvasUI = GetComponent<CanvasUI>();

        _firstStartPanelViewButton.onClick.AddListener(_canvasUI.OnFirstStartPanelViewButtonPressed);
        _firstStartPanelViewButton.onClick.AddListener(GameManager.Instance.OnFirstStartPanelViewButtonPressed);

        _startEducationButton.onClick.AddListener(_canvasUI.OnStartEducationButtonPressed);

        _skipEducationButton.onClick.AddListener(GameManager.Instance.OnEducationCancelled);
        _skipEducationButton.onClick.AddListener(_canvasUI.OnSkipeducationButtonPressed);
    }

    public void OnRestartButtonPresed()
    {
        SceneManager.LoadScene(0);
    }

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
