using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstStartPanelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _yesButton;
    [SerializeField] private TMP_Text _yesButtonText;

    private FirstStartTextSO _firstStartTextSO;

    public Action IsStarted;

    private void Start()
    {
        Show();
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnYesButtonPressed()
    {
        _yesButton.gameObject.SetActive(false);
        PrintText(_firstStartTextSO.RunText);
        IsStarted?.Invoke();
    }

    private void Show()
    {
        PrintText(_firstStartTextSO.WelcomeTex);
        _yesButtonText.text = _firstStartTextSO.YesButtonText;
    }

    private void PrintText(string text)
    {
        _text.text = text;
    }
}
