using MainCanvas;
using SettingsForYG;
using SO;
using System;
using System.Collections.Generic;
using UnityEngine;
using Indexies;

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