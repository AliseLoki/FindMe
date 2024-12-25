using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SO;

[RequireComponent(typeof(TextEqualizer))]
public class EducationUI : MonoBehaviour
{
    [SerializeField] private Button _startEducationButton;
    [SerializeField] private Button _skipEducationButton;
    [SerializeField] private Button _nextAdviceButton;
    [SerializeField] private Button _previousAdviceButton;

    [SerializeField] private TMP_Text _educationText;
    [SerializeField] private TMP_Text _startEducationButtonText;
    [SerializeField] private TMP_Text _skipEducationButtonText;

    [SerializeField] private GameStatesSwitcher _gamesStatesSwitcher;

    private int _index = 0;

    private TextEqualizer _textEqualizer;
    private EducationAdvicesSO _educationAdvicesSO;

    private void Awake()
    {
        _textEqualizer = GetComponent<TextEqualizer>();
        _nextAdviceButton.gameObject.SetActive(false);
        _previousAdviceButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        ShowAdvice(_educationAdvicesSO.FirstEducationText);
        InitText();
        _textEqualizer.MakeAllTextSameSize(_startEducationButtonText, _skipEducationButtonText);
    }

    public void InitEducationAdvicesSO(EducationAdvicesSO educationAdvicesSO)
    {
        _educationAdvicesSO = educationAdvicesSO;
    }

    public void OnStartEducationButtonPressed()
    {
        HideButtons();
        _nextAdviceButton.gameObject.SetActive(true);
        _previousAdviceButton.gameObject.SetActive(true);
        ShowAdvice(_educationAdvicesSO.Advices[0]);
    }

    public void OnSkipEducationButtonPressed()
    {
        _gamesStatesSwitcher.OnEducationCancelled();     
    }

    public void OnNextAdviceButtonPressed()
    {
        if (_index == _educationAdvicesSO.Advices.Count - 1)
        {
            _skipEducationButton.gameObject.SetActive(true);
        }

        if (_index < _educationAdvicesSO.Advices.Count - 1)
        {
            _index++;
            ShowAdvice(_educationAdvicesSO.Advices[_index]);
        }
    }

    public void OnPreviousAdviceButtonPressed()
    {
        if (_index < _educationAdvicesSO.Advices.Count && _index > 0)
        {
            _index--;
            ShowAdvice(_educationAdvicesSO.Advices[_index]);
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

    private void InitText()
    {
        _startEducationButtonText.text = _educationAdvicesSO.StartEducationButtonText;
        _skipEducationButtonText.text = _educationAdvicesSO.SkipEducationButtonText;
    }
}
