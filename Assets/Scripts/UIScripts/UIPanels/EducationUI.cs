using System.Collections.Generic;
using GameControllers;
using SettingsForYG;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIPanels
{
    public class EducationUI : MonoBehaviour
    {
        [SerializeField] private Button _skipEducationButton;
        [SerializeField] private Button _nextAdviceButton;
        [SerializeField] private Button _previousAdviceButton;
        [SerializeField] private Image _textBackground;
        [SerializeField] private TMP_Text _preEducationText;
        [SerializeField] private TMP_Text _educationText;
        [SerializeField] private TMP_Text _skipEducationButtonText;
        [SerializeField] private GameStatesSwitcher _gamesStatesSwitcher;

        private List<string> _educationTexts;

        private int _index = 0;

        public void InitEducationTexts(AllPhrases phrases)
        {
            _educationTexts = phrases.Education;
            _preEducationText.text = phrases.PreEducationText;
            _skipEducationButtonText.text = phrases.SkipEducationButtonText;
            ShowPreEducationText(true);
        }

        public void ShowPreEducationText(bool isActive)
        {
            _preEducationText.gameObject.SetActive(isActive);
        }

        public void ShowEducation()
        {
            ShowPreEducationText(false);
            _textBackground.gameObject.SetActive(true);
            _skipEducationButton.gameObject.SetActive(true);
            _educationText.text = _educationTexts[_index];
        }

        public void OnSkipEducationButtonPressed()
        {
            _gamesStatesSwitcher.OnEducationCancelled();
        }

        public void OnNextAdviceButtonPressed()
        {
            if (_index < _educationTexts.Count - 1)
            {
                _index++;
                _educationText.text = _educationTexts[_index];
            }
        }

        public void OnPreviousAdviceButtonPressed()
        {
            if (_index < _educationTexts.Count && _index > 0)
            {
                _index--;
                _educationText.text = _educationTexts[_index];
            }
        }
    }
}