using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private GameState _gameState;
    private float _waitingToStartTimer = 1f;
    private float _countdownToStartTimer = 5f;
    //private float _waitingToStartTimer = 1f;

    public event Action GameStateChanged;

    private void Awake()
    {
        Instance = this;
        _gameState = GameState.WaitingToStart;
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.WaitingToStart:

                _waitingToStartTimer -= Time.deltaTime;

                if (_waitingToStartTimer < 0f)
                {
                    _gameState = GameState.CountdownToStart;
                    GameStateChanged?.Invoke();
                }

                break;

            case GameState.CountdownToStart:

                _countdownToStartTimer -= Time.deltaTime;

                if (_countdownToStartTimer < 0f)
                {
                    _gameState = GameState.GamePlaying;
                    GameStateChanged?.Invoke();
                }

                break;

            case GameState.GamePlaying:

              //  _gameState = GameState.GameOver;
              GameStateChanged?.Invoke();
                break;

            case GameState.GameOver:
                break;
        }

        print(_gameState);
    }

    public bool IsGamePlaying()
    {
        return _gameState == GameState.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return _gameState == GameState.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
    }
}
