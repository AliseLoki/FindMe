using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(YandexLeaderboard))]
[RequireComponent(typeof(CanvasUI))]
public class CanvasUIButtonsController : MonoBehaviour
{
    private const string LeaderboardName = "LeaderboardPlayers";

    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;

    [SerializeField] private Button _firstStartPanelViewButton;
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;

    [SerializeField] private Button _showAdButton;

    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private YandexLeaderboard _yandexLeaderboard;
    private CanvasUI _canvasUI;

    private void Awake()
    {
        _canvasUI = GetComponent<CanvasUI>();
        _yandexLeaderboard = GetComponent<YandexLeaderboard>();

        _firstStartPanelViewButton.onClick.AddListener(_canvasUI.OnFirstStartPanelViewButtonPressed);
        _firstStartPanelViewButton.onClick.AddListener(_gameStatesSwitcher.OnFirstStartPanelViewButtonPressed);

        _startEducationButton.onClick.AddListener(_canvasUI.OnStartEducationButtonPressed);

        _skipEducationButton.onClick.AddListener(_canvasUI.OnSkipeducationButtonPressed);
    }

    public void OnCloseLeaderboardButtonPressed()
    {
        _canvasUI.CloseLeaderboardView();
    }

    public void OnLeaderboardButtonPressed()
    {
        if (YandexGame.auth == false)
        {
            _canvasUI.ShowAuthorisePanel();
        }
        else
        {
            YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
            // PlayerAccount.RequestPersonalProfileDataPermission();
            _canvasUI.ShowLeaderboardView();
            _yandexLeaderboard.Fill();
        }
    }

    public void OnRestartButtonPresed()
    {
        _canvasUI.ShowInterstitialAd();
        SceneManager.LoadScene(0);
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

    //на кнопке подарка
    public void OnShowVideoAdButtonPressed()
    {
        _canvasUI.ShowRewardedVideoAd();
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
