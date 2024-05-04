using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EducationUI : MonoBehaviour
{
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;
    [SerializeField] private TMP_Text _educationText;
    [SerializeField] private Button _nextAdviceButton;
    [SerializeField] private EducationAdvicesSO _educationAdvicesSO;

    private int _index = 0;

    public event Action EducationStarted;
    public event Action EducationSkipped;


    private void Awake()
    {
        _nextAdviceButton.gameObject.SetActive(false);
    }

    public void OnStartEducationButtonPressed()
    {
        EducationStarted?.Invoke();
        HideButtons();
        _nextAdviceButton.gameObject.SetActive(true);
        OnNextAdviceButtonPressed();
    }

    public void OnSkipEducationButtonPressed()
    {
        EducationSkipped?.Invoke();
    }

    public void OnNextAdviceButtonPressed()
    {
        if (_index == _educationAdvicesSO._advices.Count - 1)
        {
            _skipEducationButton.gameObject.SetActive(true);
        }

        if (_index < _educationAdvicesSO._advices.Count)
        {
            ShowAdvice(_educationAdvicesSO._advices[_index]);
            _index++;
        }
        else
        {
            _index = 0;
        }
    }

    private void ShowAdvice(string advice)
    {
        _educationText.text = advice;
    }

    private void HideButtons()
    {
        _startEducationButton.gameObject.SetActive(false);
        _skipEducationButton.gameObject.SetActive(false);
    }
}
