using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

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
    [SerializeField] private TestFocus _testFocus;
    [SerializeField] private AuthorisePanel _authorisePanel;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private SaveGameView _saveGameView;
    [SerializeField] private Spawner _spawner;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;
    private bool _canShowAd;
    private bool _isAdPlaying;

    private float _fadeSpeed = 0.5f;
    private float _timer;
    private float _timerMax = 60f;

    [SerializeField] private Player _player;
    [SerializeField] private LanguageSwitcher _languageSwitcher;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private YandexLeaderboard _yandexLeaderboard;
    private CanvasUIButtonsController _canvasUIButtonController;

    public bool IsAdPlaying => _isAdPlaying;

    private void Awake()
    {
        _timer = _timerMax;

        _yandexLeaderboard = GetComponent<YandexLeaderboard>();
        _canvasUIButtonController = GetComponent<CanvasUIButtonsController>();
        _languageSwitcher.AllSOWereGiven += OnAllSOWereGiven;
    }

    private void OnEnable()
    {
        _gameStatesSwitcher.WaitingToStartEnabled += OnWaitingToStartEnabled;
        _gameStatesSwitcher.CountdownToStartEnabled += OnCountdownToStartEnabled;
        _gameStatesSwitcher.EducationPlayingEnabled += OnEducationPlayingEnabled;
        _gameStatesSwitcher.EducationStarted += OnEducationStarted;

        _player.PlayerEventsHandler.PlayerHasDied += OnPlayerhasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome += PlayerEnteredGrannysHome;
    }

    private void OnDisable()
    {
        _gameStatesSwitcher.WaitingToStartEnabled -= OnWaitingToStartEnabled;
        _gameStatesSwitcher.CountdownToStartEnabled -= OnCountdownToStartEnabled;
        _gameStatesSwitcher.EducationPlayingEnabled -= OnEducationPlayingEnabled;
        _gameStatesSwitcher.EducationStarted -= OnEducationStarted;

        _languageSwitcher.AllSOWereGiven -= OnAllSOWereGiven;

        _player.PlayerEventsHandler.PlayerHasDied -= OnPlayerhasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome -= PlayerEnteredGrannysHome;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _canShowAd = true;
        }
    }

    public void ShowRewardedVideoAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.VideoAd.Show(OnOpen, OnGiveReward, OnClose);
#endif
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

    public void FadeToBlack()
    {
        _fadeScreen.gameObject.SetActive(true);
        _shouldFadeToBlack = true;
        StartCoroutine(FadeRoutine());
    }

    public void ShowInterstitialAd()
    {
        if (_canShowAd)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.InterstitialAd.Show(OnOpen, OnClose);
#endif
            _canShowAd = false;
        }
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
    }

    private void OnOpen()
    {
        _testFocus.StopGame(true);
        _isAdPlaying = true;
        _canvasUIButtonController.DeactivateShowAdButton();
    }

    private void OnGiveReward()
    {
        _spawner.GiveRewardForWatchingAd();
    }

    private void OnClose(bool state)
    {
        _testFocus.StopGame(false);
        _isAdPlaying = false;
        _canvasUIButtonController.ActivateShowAdButton();
    }

    private void OnClose()
    {
        _testFocus.StopGame(false);
        _isAdPlaying = false;
        _canvasUIButtonController.ActivateShowAdButton();
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
    }

    private void PlayerEnteredGrannysHome()
    {
        _tipsViewPanel.gameObject.SetActive(true);
    }
}
