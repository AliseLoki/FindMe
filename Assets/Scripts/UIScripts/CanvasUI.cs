using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    private float _fadeSpeed = 0.5f;

    public void ShowTipsPanelView()
    {
        if(_tipsViewPanel.gameObject.activeSelf)
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
}
