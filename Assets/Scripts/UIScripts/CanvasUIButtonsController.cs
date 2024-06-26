using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(CanvasUI))]
public class CanvasUIButtonsController : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;

    [SerializeField] private Button _firstStartPanelViewButton;
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private TestFocus _testFocus;

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
        SceneManager.LoadScene(1);
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

    public void OnShowVideoAdButtonPressed()
    {
        Agava.YandexGames.VideoAd.Show(OnOpen, OnGiveReward, OnClose);
    }

    private void OnOpen()
    {
        _testFocus.StopGame(true);
    }

    private void OnGiveReward()
    {
        _spawner.GiveRewardForWatchingAd();
    }

    private void OnClose()
    {
        _testFocus.StopGame(false);
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
