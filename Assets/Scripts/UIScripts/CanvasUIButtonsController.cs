using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(YandexLeaderboard))]
[RequireComponent(typeof(CanvasUI))]
public class CanvasUIButtonsController : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;

    [SerializeField] private Button _firstStartPanelViewButton;
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;

    [SerializeField] private Button _showAdButton;

    private YandexLeaderboard _yandexLeaderboard;
    private CanvasUI _canvasUI;

    private void Awake()
    {
        _canvasUI = GetComponent<CanvasUI>();
        _yandexLeaderboard = GetComponent<YandexLeaderboard>();

        _firstStartPanelViewButton.onClick.AddListener(_canvasUI.OnFirstStartPanelViewButtonPressed);
        _firstStartPanelViewButton.onClick.AddListener(GameManager.Instance.OnFirstStartPanelViewButtonPressed);

        _startEducationButton.onClick.AddListener(_canvasUI.OnStartEducationButtonPressed);

        _skipEducationButton.onClick.AddListener(_canvasUI.OnSkipeducationButtonPressed);
    }

    public void ActivateShowAdButton()
    {
        _showAdButton.gameObject.SetActive(true);
    }

    public void DeactivateShowAdButton()
    {
        _showAdButton.gameObject.SetActive(false);
    }

    public void OnCloseLeaderboardButtonPressed()
    {
        _canvasUI.CloseLeaderboardView();
    }

    public void OnLeaderboardButtonPressed()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            _canvasUI.ShowAuthorisePanel();
        }
        else if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _canvasUI.ShowLeaderboardView();
            _yandexLeaderboard.Fill();
        }
    }

    public void OnRestartButtonPresed()
    {
        _canvasUI.ShowInterstitialAd();
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
        if (_canvasUI.IsAdPlaying == false)
        {
            _canvasUI.ShowRewardedVideoAd();
        }
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
