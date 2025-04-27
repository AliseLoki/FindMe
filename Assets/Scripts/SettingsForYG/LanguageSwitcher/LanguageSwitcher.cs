using MainCanvas;
using SO;
using System;
using UnityEngine;
using YG;

namespace SettingsForYG
{
    public class LanguageSwitcher : MonoBehaviour
    {
        private const string English = "en";
        private const string Russian = "ru";
        private const string Turkish = "tr";

        [SerializeField] private AllTextsSO _russianTextsSO;

        [SerializeField] private CanvasUI _canvasUI;

        private string _currentLanguage;


        [SerializeField] private TipsSO _englishTipsSO;
        [SerializeField] private TipsSO _russianTipsSO;
        [SerializeField] private TipsSO _turkishTipsSO;

        [SerializeField] private EducationAdvicesSO _englishEducationAdvicesSO;
        [SerializeField] private EducationAdvicesSO _russianEducationAdvicesSO;
        [SerializeField] private EducationAdvicesSO _turkishEducationAdvicesSO;

        [SerializeField] private FirstStartTextSO _englishFirstStartTextSO;
        [SerializeField] private FirstStartTextSO _russianFirstStartTextSO;
        [SerializeField] private FirstStartTextSO _turkishFirstStartTextSO;

        [SerializeField] private GameOverSO _englishGameOverSO;
        [SerializeField] private GameOverSO _russianGameOverSO;
        [SerializeField] private GameOverSO _turkishGameOverSO;

        public event Action<TipsSO, EducationAdvicesSO, FirstStartTextSO, GameOverSO> AllSOWereGiven;

        public event Action<SignSO> SignSOGiven;

        public GameOverSO GameOverSO { get; private set; }

        private void Awake()
        {
            InitCurrentLanguage(YandexGame.EnvironmentData.language);
            InitSO();
        }

        private void Start()
        {
            InitSO();
        }

        private void InitCurrentLanguage(string language)
        {
            _currentLanguage = language;
            print("Switcher1");
        }

        private void InitSO()
        {
            print("Switcher2");

            if (_currentLanguage == English)
            {
                SetLanguage(_englishTipsSO, _englishEducationAdvicesSO, _englishFirstStartTextSO, _englishGameOverSO);
            }
            else if (_currentLanguage == Russian)
            {
                SetLanguage(_russianTipsSO, _russianEducationAdvicesSO, _russianFirstStartTextSO, _russianGameOverSO);
            }
            else if (_currentLanguage == Turkish)
            {
                SetLanguage(_turkishTipsSO, _turkishEducationAdvicesSO, _turkishFirstStartTextSO, _turkishGameOverSO);
            }
        }

        private void SetLanguage(TipsSO tips, EducationAdvicesSO advices, FirstStartTextSO startText, GameOverSO gameOver)
        {
            AllSOWereGiven?.Invoke(tips, advices, startText, gameOver);
            GameOverSO = gameOver;
        }
    }
}
