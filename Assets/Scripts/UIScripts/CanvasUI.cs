using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private FirstStartPanelView _firstStartPanel;
    [SerializeField] private EducationUI _educationUI;
    [SerializeField] private GameOverUI _gameOverUI;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private float _fadeSpeed = 0.5f;

    private Player _player;

    public FirstStartPanelView FirstStartPanel => _firstStartPanel;
    public EducationUI EducationUI => _educationUI;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();

        _tipsViewPanel.gameObject.SetActive(false);

        if (GameManager.Instance.IsFirstStart)
        {
            ShowFirstStartPanelView();
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
        GameManager.Instance.EducationStarted += OnEducationStarted;
        _player.PlayerEventsHandler.PlayerHasDied += OnGameOver;
        _player.PlayerEventsHandler.EnteredGrannysHome += PlayerEnteredGrannysHome;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameStateChanged -= OnGameStateChanged;
        GameManager.Instance.EducationStarted -= OnEducationStarted;
        _player.PlayerEventsHandler.PlayerHasDied -= OnGameOver;
        _player.PlayerEventsHandler.EnteredGrannysHome -= PlayerEnteredGrannysHome;
    }

    private void OnGameOver()
    {
        _gameOverUI.gameObject.SetActive(true);
    }

    private void OnEducationStarted()
    {
        _educationUI.gameObject.SetActive(true);
        HideTipsPanel();
    }
    public void ShowFirstStartPanelView()
    {
        _firstStartPanel.Show();
    }

    public void ShowOrHideTipsPanelView()
    {
        if (_tipsViewPanel.gameObject.activeSelf)
        {
            HideTipsPanel();
        }
        else
        {
            ShowTipsPanel();
        }
    }

    public void FadeToBlack()
    {
        _fadeScreen.gameObject.SetActive(true);
        _shouldFadeToBlack = true;
        StartCoroutine(FadeRoutine());
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

    private void OnGameStateChanged()
    {
        _firstStartPanel.Hide();
        _educationUI.gameObject.SetActive(false);
    }

    private void ShowTipsPanel()
    {
        _tipsViewPanel.gameObject.SetActive(true);
    }

    private void HideTipsPanel()
    {
        _tipsViewPanel.gameObject.SetActive(false);
    }

    private void PlayerEnteredGrannysHome()
    {
        if (GameManager.Instance.IsEducationPlaying())
        {
            ShowTipsPanel();
        }
    }
}
