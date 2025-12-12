using GameControllers;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainCanvas
{
    public class CanvasUIButtonsController : MonoBehaviour
    {
        [SerializeField] private Button _skipEducationButton;
        [SerializeField] private Button _fullRestartButton;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private SaveData _saveData;
        [SerializeField] private CanvasUI _canvasUI;

        private void Awake()
        {
            _skipEducationButton.onClick.AddListener(_canvasUI.OnSkipeducationButtonPressed);
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
