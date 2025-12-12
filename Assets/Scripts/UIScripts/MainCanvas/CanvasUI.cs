using System.Collections;
using GameControllers;
using LeaderboardSystem;
using PlayerController;
using SettingsForYG;
using TMPro;
using UIPanels;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace MainCanvas
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private Image _fadeScreen;
        [SerializeField] private EducationUI _educationUI;
     
        [SerializeField] private GameObject _settingView;

        [SerializeField] private YandexGame _yandexGame;
        [SerializeField] private Player _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private TMP_Text _gameSavedText;
        [SerializeField] private TMP_Text _restartButtonText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private CanvasUILanguageSetter _languageSetter;

        private bool _shouldFadeToBlack;
        private bool _shouldFadeFromBlack;
        private float _fadeSpeed = 0.5f;

        public CanvasUILanguageSetter LanguageSetter => _languageSetter;

        private void Awake()
        {
            _languageSetter.LanguageInitialized += OnLanguageInitialized;
            _gameSavedText.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _gameStatesSwitcher.EducationPlayingEnabled += OnEducationPlayingEnabled;
            _gameStatesSwitcher.EducationStarted += OnEducationStarted;
            _player.PlayerHealth.PlayerHasDied += OnPlayerhasDied;
        }

        private void OnDisable()
        {
            _gameStatesSwitcher.EducationPlayingEnabled -= OnEducationPlayingEnabled;
            _gameStatesSwitcher.EducationStarted -= OnEducationStarted;
            _languageSetter.LanguageInitialized -= OnLanguageInitialized;
            _player.PlayerHealth.PlayerHasDied -= OnPlayerhasDied;
        }

        public void OnAuthorizeButtonPressed()
        {
            YandexGame.AuthDialog();
        }

        public void ShowSavedScreen()
        {
            _gameSavedText.gameObject.SetActive(true);
            StartCoroutine(Timer());
        }

        public void ShowRewardedVideoAd()
        {
            _yandexGame._RewardedShow(1);
        }

        public void OnSkipeducationButtonPressed()
        {
            _educationUI.OnSkipEducationButtonPressed();
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

        private void OnLanguageInitialized(AllPhrases phrases)
        {
            _educationUI.InitEducationTexts(phrases);
            _gameSavedText.text = phrases.SaveGameText;
            _restartButtonText.text = phrases.Restart;
        }

        private void OnEducationPlayingEnabled()
        {
            _educationUI.gameObject.SetActive(true);
        }

        private void OnEducationStarted()
        {
            _educationUI.ShowEducation();
        }

        private void OnPlayerhasDied()
        {
            _restartButton.gameObject.SetActive(true);
        }

        private IEnumerator FadeRoutine()
        {
            while (_shouldFadeToBlack)
            {
                _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 1f, _fadeSpeed * Time.deltaTime));

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
                _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 0f, _fadeSpeed * Time.deltaTime));

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

        private IEnumerator Timer()
        {
            int pause = 2;
            yield return new WaitForSeconds(pause);
            _gameSavedText.gameObject.SetActive(false);
            StopCoroutine(Timer());
        }
    }
}