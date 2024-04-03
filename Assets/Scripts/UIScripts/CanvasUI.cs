using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private FirstStartPanelView _firstStartPanel;
    [SerializeField] private EducationUI _educationUI;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private float _fadeSpeed = 0.5f;

    public FirstStartPanelView FirstStartPanel;

    private void Awake()
    {
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
        Player.Instance.PlayerEventsHandler.EnteredGrannysHome += PlayerEnteredGrannysHome;
    }

    private void OnEducationStarted()
    {
        _educationUI.gameObject.SetActive(true);
        HideTipsPanel();
    }

    private void OnDisable()
    {
        GameManager.Instance.GameStateChanged -= OnGameStateChanged;
        GameManager.Instance.EducationStarted -= OnEducationStarted;
        Player.Instance.PlayerEventsHandler.EnteredGrannysHome -= PlayerEnteredGrannysHome;
    }

    public void ShowFirstStartPanelView()
    {
        _firstStartPanel.Show();
    }

    public void OnExitToMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
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
