using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using SaveSystem;
using LeaderboardSystem;

[RequireComponent(typeof(YandexLeaderboard))]
[RequireComponent(typeof(CanvasUI))]
public class CanvasUIButtonsController : MonoBehaviour
{
    private const string LeaderboardName = "LeaderboardPlayers";

    [SerializeField] private Button _firstStartPanelViewButton;
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;

    [SerializeField] private Button _fullRestartButton;

    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
    [SerializeField] private SaveData _saveData;

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
            _canvasUI.ShowLeaderboardView();
            _yandexLeaderboard.Fill();
        }
    }

    public void OnRestartButtonPresed()
    {
        _canvasUI.ShowInterstitialAd();
        SceneManager.LoadScene(0);
    }

    public void OnShowVideoAdButtonPressed()
    {
        _canvasUI.ShowRewardedVideoAd();
    }
}
