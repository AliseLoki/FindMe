using System.Collections.Generic;
using Indexies;
using MainCanvas;
using SettingsForYG;
using UnityEngine;

namespace AllSigns
{
    public class Signs : MonoBehaviour
    {
        [SerializeField] private List<Sign> _signs;
        [SerializeField] private CanvasUI _canvasUI;

        private void OnEnable()
        {
            _canvasUI.LanguageSetter.LanguageInitialized += OnLanguageInitialized;
        }

        private void OnDisable()
        {
            _canvasUI.LanguageSetter.LanguageInitialized -= OnLanguageInitialized;
        }

        private void OnLanguageInitialized(AllPhrases phrases)
        {
            for (int i = 0; i < _signs.Count; i++)
            {
                _signs[i].InitPointerNames(phrases.AllSignsText[(SignsNumbers)i]);
            }
        }
    }
}