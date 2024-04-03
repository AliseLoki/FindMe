using System;
using System.Net;
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

    [SerializeField] private CanvasUI _canvasUI;

    private GameState _gameState;

    private float _waitingToStartTimer = 1f;
    private float _countdownToStartTimer = 5f;
    private float _showEducationTipsTimer = 20f;

    private bool _isFirstStart = true;
    private bool _isStarted;

    public event Action GameStateChanged;
    public event Action EducationStarted;
    public event Action EducationCancelled;

    public bool IsFirstStart => _isFirstStart;

    private void Awake()
    {
        Instance = this;
        _gameState = GameState.WaitingToStart;
    }


    private void OnEnable()
    {
        _canvasUI.FirstStartPanel.IsStarted += OnIsStarted;
    }

    private void OnDisable()
    {
        _canvasUI.FirstStartPanel.IsStarted -= OnIsStarted;
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

                _showEducationTipsTimer -= Time.deltaTime;

                if(_showEducationTipsTimer < 0f)
                {
                    EducationStarted?.Invoke();
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _gameState = GameState.GamePlaying;
                    EducationCancelled?.Invoke();
                }

                break;

            case GameState.GamePlaying:

                if (Input.GetKeyDown(KeyCode.E))
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
}
