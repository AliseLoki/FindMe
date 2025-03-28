using Enemies;
using PlayerController;
using System;
using UIPanels;
using UnityEngine;
using UnityEngine.SceneManagement;
using Villages;
using YG;

namespace GameControllers
{
    public class GameStatesSwitcher : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TipsViewPanel _tipsViewPanel;
        [SerializeField] private LastVillage _lastVillage;
        [SerializeField] private EducationUI _educationUI;

        private int _finalGameOverSceneIndex = 1;
        private int _winSceneIndex = 2;

        private Witch _witch;
        private GameStates _gameState;

        private float _waitingToStartTimer = 4f;
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

        public bool IsFirstStart => _isFirstStart;

        private void OnEnable()
        {
            _player.PlayerHealth.PlayerHasDied += OnPlayerHasDied;
            _lastVillage.WitchAppeared += OnWitchAppeared;
        }

        private void OnDisable()
        {
            _player.PlayerHealth.PlayerHasDied -= OnPlayerHasDied;
            _lastVillage.WitchAppeared -= OnWitchAppeared;
        }

        private void Update()
        {
            switch (_gameState)
            {
                case GameStates.WaitingToStart:

                    WaitingToStartEnabled?.Invoke();

                    if (_isReadyToStart)
                    {
                        _waitingToStartTimer -= Time.deltaTime;

                        if (_waitingToStartTimer < 0f)
                        {
                            _gameState = GameStates.CountdownToStart;
                            CountdownToStartEnabled?.Invoke();
                        }
                    }

                    break;

                case GameStates.CountdownToStart:

                    _countdownToStartTimer -= Time.deltaTime;

                    if (_countdownToStartTimer < 0f)
                    {
                        _gameState = GameStates.EducationPlaying;
                        EducationPlayingEnabled?.Invoke();
                    }

                    break;

                case GameStates.EducationPlaying:

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
                        _gameState = GameStates.GamePlaying;
                    }

                    if (_isGameOver)
                    {
                        _gameState = GameStates.GameOver;
                    }

                    break;

                case GameStates.GamePlaying:

                    _educationUI.gameObject.SetActive(false);
                    _isFirstStart = false;

                    if (_isGameOver)
                    {
                        _gameState = GameStates.GameOver;
                    }

                    if (_hasWitchAppeared)
                    {
                        _gameState = GameStates.WitchAppeared;
                    }

                    break;

                case GameStates.WitchAppeared:

                    _tipsViewPanel.ShowUseNecronomikonTip();

                    if (_witchIsDead)
                    {
                        YandexGame.ResetSaveProgress();
                        YandexGame.SaveProgress();
                        SceneManager.LoadScene(_winSceneIndex);
                    }

                    break;

                case GameStates.GameOver:

                    break;
            }
        }

        public void SetFirstStart(bool isTrue)
        {
            _isFirstStart = isTrue;

            if (_isFirstStart)
            {
                _gameState = GameStates.WaitingToStart;
            }
            else
            {
                _gameState = GameStates.GamePlaying;
            }
        }

        public void WitchKilledPlayer()
        {
            SceneManager.LoadScene(_finalGameOverSceneIndex);
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
            return _gameState == GameStates.GamePlaying || _gameState == GameStates.EducationPlaying;
        }

        public bool IsEducationPlaying()
        {
            return _gameState == GameStates.EducationPlaying;
        }

        public bool IsGameFinished()
        {
            return _gameState == GameStates.GameOver || _gameState == GameStates.WitchAppeared;
        }

        public bool IsWitchAppeared()
        {
            return _gameState == GameStates.WitchAppeared;
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
    }
}