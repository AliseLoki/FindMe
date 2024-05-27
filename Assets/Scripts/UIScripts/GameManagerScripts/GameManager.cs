using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string PlayerPrefsIsFirstStart = nameof(PlayerPrefsIsFirstStart);

    public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        EducationPlaying,
        GamePlaying,
        WitchAppeared,
        GameOver
    }

    private Player _player;
    private Witch _witch;
    private TipsViewPanel _tipsViewPanel;

    [SerializeField] private EntryPoint _gameEntryPoint;
    [SerializeField] private LastVillage _lastVillage;

    public EntryPoint GameEntryPoint => _gameEntryPoint;

    private GameState _gameState;

    private float _waitingToStartTimer = 2f;
    private float _countdownToStartTimer = 5f;
    private float _showEducationTipsTimer = 4f;

    private bool _isFirstStart;

    private bool _isReadyToStart;
    private bool _isEnteredGrannysHome;
    private bool _isEducationCancelled;
    private bool _hasWitchAppeared;
    private bool _witchIsDead;
    private bool _isGameOver;

    public event Action WaitingToStartEnabled;
    public event Action CountdownToStartEnabled;
    public event Action EducationPlayingEnabled;
    public event Action EducationStarted;
    public event Action WitchIsDead;
    
    public bool IsFirstStart => _isFirstStart;

    private void Awake()
    {
        Instance = this;
        _player = _gameEntryPoint.InitPlayer();
        SetFirstStart(PlayerPrefs.GetInt(PlayerPrefsIsFirstStart, 1));
        _tipsViewPanel = _gameEntryPoint.InitTipsViewPanel();
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.EnteredGrannysHome += OnPlayerEnteredGrannysHome;
        _player.PlayerEventsHandler.PlayerHasDied += OnPlayerHasDied;
        _lastVillage.WitchAppeared += OnWitchAppeared;
    }


    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredGrannysHome -= OnPlayerEnteredGrannysHome;
        _player.PlayerEventsHandler.PlayerHasDied -= OnPlayerHasDied;
        _lastVillage.WitchAppeared -= OnWitchAppeared;
        _witch.WitchIsDead -= OnWitchIsDead;
    }

    private void Start()
    {
        if (_isFirstStart)
        {
            _gameState = GameState.WaitingToStart;
        }
        else
        {
            _gameState = GameState.GamePlaying;
        }
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.WaitingToStart:

                WaitingToStartEnabled?.Invoke();

                if (_isReadyToStart)
                {
                    _waitingToStartTimer -= Time.deltaTime;

                    if (_waitingToStartTimer < 0f)
                    {
                        _gameState = GameState.CountdownToStart;
                        CountdownToStartEnabled?.Invoke();
                    }
                }

                break;

            case GameState.CountdownToStart:

                _countdownToStartTimer -= Time.deltaTime;

                if (_countdownToStartTimer < 0f)
                {
                    _gameState = GameState.EducationPlaying;
                    EducationPlayingEnabled?.Invoke();
                }

                break;

            case GameState.EducationPlaying:

                if (_isEnteredGrannysHome)
                {
                    _showEducationTipsTimer -= Time.deltaTime;

                    if (_showEducationTipsTimer < 0f)
                    {
                        EducationStarted?.Invoke();
                    }
                }

                if (_isEducationCancelled)
                {
                    _gameState = GameState.GamePlaying;
                }

                if (_isGameOver)
                {
                    _gameState = GameState.GameOver;
                }

                break;

            case GameState.GamePlaying:

                SaveState(0, false);

                if (_isGameOver)
                {
                    _gameState = GameState.GameOver;
                }

                if (_hasWitchAppeared)
                {
                    _gameState = GameState.WitchAppeared;
                }

                break;

            case GameState.WitchAppeared:

                _tipsViewPanel.ShowUseNecronomikonTip();

                //событие смерти ведьмы
                //победная панель
                SaveState(1, true);

                if (_witchIsDead)
                {
                    WitchIsDead?.Invoke();
                }

                if (_isGameOver)
                {
                    _gameState = GameState.GameOver;
                }

                break;

            case GameState.GameOver:

                SaveState(1, true);

                break;
        }

        print(_gameState);
    }

    public void OnFirstStartPanelViewButtonPressed()
    {
        _isReadyToStart = true;
    }

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
    }

    public void OnPlayerEnteredGrannysHome()
    {
        _isEnteredGrannysHome = true;
    }

    public void OnEducationCancelled()
    {
        _isEducationCancelled = true;
    }

    public bool IsGamePlaying()
    {
        return _gameState == GameState.GamePlaying || _gameState == GameState.EducationPlaying;
    }

    public bool IsEducationPlaying()
    {
        return _gameState == GameState.EducationPlaying;
    }

    public bool IsWitchAppeared()
    {
        return _gameState == GameState.WitchAppeared;
    }

    private void OnPlayerHasDied()
    {
        _isGameOver = true;
    }

    private void OnWitchAppeared(Witch witch)
    {
        _hasWitchAppeared = true;
        _witch = witch;
        _witch.WitchIsDead += OnWitchIsDead;
    }

    private void OnWitchIsDead()
    {
        _witchIsDead = true;
    }

    private void SaveState(int value, bool isTrue)
    {
        _isFirstStart = isTrue;
        PlayerPrefs.SetInt(PlayerPrefsIsFirstStart, value);
        PlayerPrefs.Save();
    }

    private void SetFirstStart(int value)
    {
        if (value == 1)
        {
            _isFirstStart = true;
        }
        else if (value == 0)
        {
            _isFirstStart = false;
        }
    }
}
