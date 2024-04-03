using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstStartPanelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _yesButton;

    private string _welcomeText = "готов ли ты начать приключение?";
    private string _runText = "тогда беги вперед!!!";

    public Action IsStarted;

    public void Show()
    {
        gameObject.SetActive(true);
        PrintText(_welcomeText);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnYesButtonPressed()
    {
        _yesButton.gameObject.SetActive(false);
        PrintText(_runText);
        IsStarted?.Invoke();
    }

    private void PrintText(string text)
    {
        _text.text = text;
    }
}
