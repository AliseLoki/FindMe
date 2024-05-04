using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        EducationPlaying,
        GamePlaying,
        GameOver
    }

    private Player _player;

    [SerializeField] private bool _isFirstStart = true;

    [SerializeField] private CanvasUI _canvasUI;

    [SerializeField] private EntryPoint _gameEntryPoint;

    public EntryPoint GameEntryPoint => _gameEntryPoint;

    private GameState _gameState;

    private float _waitingToStartTimer = 1f;
    private float _countdownToStartTimer = 5f;
    private float _showEducationTipsTimer = 4f;

    private bool _isStarted;
    private bool _isEducationCancelled;
    private bool _isEnteredGrannysHome;
    private bool _isGameOver;

    public event Action GameStateChanged;
    public event Action EducationStarted;

    public bool IsFirstStart => _isFirstStart;

    private void Awake()
    {
        Instance = this;
        _player = _gameEntryPoint.InitPlayer();
        _gameState = GameState.WaitingToStart;
    }

    private void OnEnable()
    {
        _canvasUI.FirstStartPanel.IsStarted += OnIsStarted;
        _canvasUI.EducationUI.EducationSkipped += OnEducationCancelled;
        _player.PlayerEventsHandler.PlayerHasDied += OnPlayerHasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome += OnPlayerEnteredGrannysHome;
    }

    private void OnDisable()
    {
        _canvasUI.FirstStartPanel.IsStarted -= OnIsStarted;
        _canvasUI.EducationUI.EducationSkipped -= OnEducationCancelled;
        _player.PlayerEventsHandler.PlayerHasDied -= OnPlayerHasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome -= OnPlayerEnteredGrannysHome;
    }

    private void Update()
    {
        if (!_isFirstStart)
        {
            _gameState = GameState.GamePlaying;
            return;
        }

        switch (_gameState)
        {
            case GameState.WaitingToStart:

                if (_isStarted)
                {
                    _waitingToStartTimer -= Time.deltaTime;

                    if (_waitingToStartTimer < 0f)
                    {
                        _gameState = GameState.CountdownToStart;
                        GameStateChanged?.Invoke();
                    }
                }

                break;

            case GameState.CountdownToStart:

                _countdownToStartTimer -= Time.deltaTime;

                if (_countdownToStartTimer < 0f)
                {
                    _gameState = GameState.EducationPlaying;
                    GameStateChanged?.Invoke();
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
                    GameStateChanged?.Invoke();
                }

                break;

            case GameState.GamePlaying:

                if (_isGameOver)
                {
                    _gameState = GameState.GameOver;
                    GameStateChanged?.Invoke();
                }

                break;

            case GameState.GameOver:

                break;
        }

        print(_gameState);
    }

    public bool IsGamePlaying()
    {
        return _gameState == GameState.GamePlaying || _gameState == GameState.EducationPlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return _gameState == GameState.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
    }

    public bool IsGameOver()
    {
        return _gameState == GameState.GameOver;
    }

    public bool IsEducationPlaying()
    {
        return _gameState == GameState.EducationPlaying;
    }

    private void OnIsStarted()
    {
        _isStarted = true;
    }

    private void OnEducationCancelled()
    {
        _isEducationCancelled = true;
    }

    private void OnPlayerHasDied()
    {
        _isGameOver = true;
    }

    public void OnPlayerEnteredGrannysHome()
    {
        _isEnteredGrannysHome = true;
    }
}
