using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;
using PlayerController;

[RequireComponent(typeof(YandexLeaderboard))]
[RequireComponent(typeof(CanvasUIButtonsController))]
public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private FirstStartPanelView _firstStartPanelView;
    [SerializeField] private GameStartCountdownUI _gameStartCountdownUI;
    [SerializeField] private EducationUI _educationUI;
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private AuthorisePanel _authorisePanel;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private SaveGameView _saveGameView;
    [SerializeField] private GameObject _settingView;
    [SerializeField] private YandexGame _yandexGame;
    [SerializeField] private SettingsView _settingsView;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private bool _isAdPlaying;

    private float _fadeSpeed = 0.5f;

    [SerializeField] private Player _player;
    [SerializeField] private LanguageSwitcher _languageSwitcher;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private YandexLeaderboard _yandexLeaderboard;

    public bool IsAdPlaying => _isAdPlaying;

    private void Awake()
    {
        _yandexLeaderboard = GetComponent<YandexLeaderboard>();
        _languageSwitcher.AllSOWereGiven += OnAllSOWereGiven;
    }

    private void OnEnable()
    {
        _gameStatesSwitcher.WaitingToStartEnabled += OnWaitingToStartEnabled;
        _gameStatesSwitcher.CountdownToStartEnabled += OnCountdownToStartEnabled;
        _gameStatesSwitcher.EducationPlayingEnabled += OnEducationPlayingEnabled;
        _gameStatesSwitcher.EducationStarted += OnEducationStarted;

        _player.PlayerHealth.PlayerHasDied += OnPlayerhasDied;
    }

    private void OnDisable()
    {
        _gameStatesSwitcher.WaitingToStartEnabled -= OnWaitingToStartEnabled;
        _gameStatesSwitcher.CountdownToStartEnabled -= OnCountdownToStartEnabled;
        _gameStatesSwitcher.EducationPlayingEnabled -= OnEducationPlayingEnabled;
        _gameStatesSwitcher.EducationStarted -= OnEducationStarted;

        _languageSwitcher.AllSOWereGiven -= OnAllSOWereGiven;

        _player.PlayerHealth.PlayerHasDied -= OnPlayerhasDied;
    }

    public void ShowRewardedVideoAd()
    {
        _yandexGame._RewardedShow(1);
    }

    public void CloseLeaderboardView()
    {
        _leaderboardView.gameObject.SetActive(false);
    }

    public void ShowLeaderboardView()
    {
        _leaderboardView.gameObject.SetActive(true);
    }

    public void ShowAuthorisePanel()
    {
        _authorisePanel.gameObject.SetActive(true);
    }

    public void CloseAuthorizePanel()
    {
        _authorisePanel.gameObject.SetActive(false);
    }

    public void OnSkipeducationButtonPressed()
    {
        _educationUI.OnSkipEducationButtonPressed();
    }

    public void OnFirstStartPanelViewButtonPressed()
    {
        _firstStartPanelView.OnFirstStartPanelViewButtonPressed();
    }

    public void OnStartEducationButtonPressed()
    {
        _educationUI.OnStartEducationButtonPressed();
    }

    public void ShowOrHideTipsPanelView()
    {
        if (_tipsViewPanel.gameObject.activeSelf)
        {
            _tipsViewPanel.gameObject.SetActive(false);
        }
        else
        {
            _tipsViewPanel.gameObject.SetActive(true);
        }
    }

    public void OnSettingViewButtonPressed()
    {
        _settingView.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnCloseSettingViewButtonPressed()
    {
        _settingView.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void FadeToBlack()
    {
        _fadeScreen.gameObject.SetActive(true);
        _shouldFadeToBlack = true;
        StartCoroutine(FadeRoutine());
    }

    public void ShowInterstitialAd()
    {
        _yandexGame._FullscreenShow();
    }

    private void OnWaitingToStartEnabled()
    {
        _firstStartPanelView.gameObject.SetActive(true);
    }

    private void OnCountdownToStartEnabled()
    {
        _firstStartPanelView.gameObject.SetActive(false);
        _gameStartCountdownUI.gameObject.SetActive(true);
    }

    private void OnEducationPlayingEnabled()
    {
        _gameStartCountdownUI.gameObject.SetActive(false);
    }

    private void OnEducationStarted()
    {
        _educationUI.gameObject.SetActive(true);
        _tipsViewPanel.gameObject.SetActive(false);
    }

    private void OnPlayerhasDied()
    {
        _gameOverUI.gameObject.SetActive(true);
    }

    private void OnAllSOWereGiven(TipsSO tipsSO, EducationAdvicesSO educationAdvicesSO, FirstStartTextSO firstStartTextSO, GameOverSO gameOverSO)
    {
        _firstStartPanelView.InitFirstStartTextSO(firstStartTextSO);
        _tipsViewPanel.InitTipsSO(tipsSO);
        _educationUI.InitEducationAdvicesSO(educationAdvicesSO);
        _gameOverUI.InitGameOverSO(gameOverSO);
        _gameStartCountdownUI.InitText(firstStartTextSO);
        _authorisePanel.InitFirstStartTextSO(firstStartTextSO);
        _leaderboardView.InitFirstStartTextSO(firstStartTextSO);
        _yandexLeaderboard.InitFirstStartTextSO(firstStartTextSO);
        _saveGameView.InitFirstStartTextSO(firstStartTextSO);
        _settingsView.InitButtonText(firstStartTextSO.FullRestartButtonText);
    }

    private IEnumerator FadeRoutine()
    {
        while (_shouldFadeToBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b,
               Mathf.MoveTowards(_fadeScreen.color.a, 1f, _fadeSpeed * Time.deltaTime));

            if (_fadeScreen.color.a == 1f)
            {
                _shouldFadeToBlack = false;
                _shouldFadeFromBlack = true;
                yield return LightRoutine();
            }
        }
    }

    private IEnumerator LightRoutine()
    {
        while (_shouldFadeFromBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b,
               Mathf.MoveTowards(_fadeScreen.color.a, 0f, _fadeSpeed * Time.deltaTime));

            if (_fadeScreen.color.a == 0f)
            {
                _shouldFadeFromBlack = false;
                _fadeScreen.gameObject.SetActive(false);
            }

            yield return null;
        }

        StopCoroutine(FadeRoutine());
        StopCoroutine(LightRoutine());
    }
}
