using GameControllers;
using LeaderboardSystem;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace MainCanvas
{
    public class CanvasUIButtonsController : MonoBehaviour
    {
        private const string LeaderboardName = "LeaderboardPlayers";

        [SerializeField] private Button _skipEducationButton;
        [SerializeField] private Button _fullRestartButton;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private SaveData _saveData;
        [SerializeField] private YandexLeaderboard _yandexLeaderboard;
        [SerializeField] private CanvasUI _canvasUI;

        private void Awake()
        {
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
}
