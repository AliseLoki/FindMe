using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasUIButtonsController))]
public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private FirstStartPanelView _firstStartPanelView;
    [SerializeField] private GameStartCountdownUI _gameStartCountdownUI;
    [SerializeField] private EducationUI _educationUI;
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private FinalPanelView _finalPanelView;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private float _fadeSpeed = 0.5f;

    private Player _player;
    private LanguageSwitcher _languageSwitcher;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
        _languageSwitcher = GameManager.Instance.GameEntryPoint.InitLanguageSwitcher();
        _languageSwitcher.AllSOWereGiven += OnAllSOWereGiven;
    }

    private void OnEnable()
    {
        GameManager.Instance.WaitingToStartEnabled += OnWaitingToStartEnabled;
        GameManager.Instance.CountdownToStartEnabled += OnCountdownToStartEnabled;
        GameManager.Instance.EducationPlayingEnabled += OnEducationPlayingEnabled;
        GameManager.Instance.EducationStarted += OnEducationStarted;
        GameManager.Instance.WitchIsDead += OnWitchIsDead;

        _player.PlayerEventsHandler.PlayerHasDied += OnPlayerhasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome += PlayerEnteredGrannysHome;
    }

    private void OnWitchIsDead()
    {
        _finalPanelView.gameObject.SetActive(true);
    }

    private void OnDisable()
    {

        GameManager.Instance.WaitingToStartEnabled -= OnWaitingToStartEnabled;
        GameManager.Instance.CountdownToStartEnabled -= OnCountdownToStartEnabled;
        GameManager.Instance.EducationPlayingEnabled -= OnEducationPlayingEnabled;
        GameManager.Instance.EducationStarted -= OnEducationStarted;
        GameManager.Instance.WitchIsDead -= OnWitchIsDead;

        _languageSwitcher.AllSOWereGiven -= OnAllSOWereGiven;
      
        _player.PlayerEventsHandler.PlayerHasDied -= OnPlayerhasDied;
        _player.PlayerEventsHandler.EnteredGrannysHome -= PlayerEnteredGrannysHome;
    }

    public void OnSkipeducationButtonPressed()
    {
        _educationUI.gameObject.SetActive(false);
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
