using SettingsForYG;
using System;
using UnityEngine;

namespace MainCanvas
{
    public class CanvasUILanguageSetter : MonoBehaviour
    {
        private const string English = "en";
        private const string Russian = "ru";
        private const string Turkish = "tr";

        public event Action<AllPhrases> LanguageInitialized;

        public void SetCurrentLanguage(string language)
        {
            if (language == Russian)
            {
                LanguageInitialized?.Invoke(new Russian());
            }
            else if (language == Turkish)
            {
                LanguageInitialized?.Invoke(new Turkish());
            }
            else if (language == English)
            {
                LanguageInitialized?.Invoke(new English());
            }
        }
    }
}