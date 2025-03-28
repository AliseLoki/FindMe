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

        [SerializeField] private VillageNamesSO _englishVillageNamesSO;
        [SerializeField] private VillageNamesSO _russianVillageNamesSO;
        [SerializeField] private VillageNamesSO _turkishVillageNamesSO;

        [SerializeField] private SignSO _englishSignSO;
        [SerializeField] private SignSO _russianSignSO;
        [SerializeField] private SignSO _turkishSignSO;

        [SerializeField] private GameOverSO _englishGameOverSO;
        [SerializeField] private GameOverSO _russianGameOverSO;
        [SerializeField] private GameOverSO _turkishGameOverSO;

        public event Action<TipsSO, EducationAdvicesSO, FirstStartTextSO, GameOverSO> AllSOWereGiven;
        public event Action<VillageNamesSO> VillageNamesGiven;
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
        }

        private void InitSO()
        {
            if (_currentLanguage == English)
            {
                SetLanguage(_englishTipsSO, _englishEducationAdvicesSO, _englishFirstStartTextSO, _englishGameOverSO, _englishVillageNamesSO, _englishSignSO);
            }
            else if (_currentLanguage == Russian)
            {
                SetLanguage(_russianTipsSO, _russianEducationAdvicesSO, _russianFirstStartTextSO, _russianGameOverSO, _russianVillageNamesSO, _russianSignSO);
            }
            else if (_currentLanguage == Turkish)
            {
                SetLanguage(_turkishTipsSO, _turkishEducationAdvicesSO, _turkishFirstStartTextSO, _turkishGameOverSO, _turkishVillageNamesSO, _turkishSignSO);
            }
        }

        private void SetLanguage(TipsSO tips, EducationAdvicesSO advices, FirstStartTextSO startText, GameOverSO gameOver, VillageNamesSO name, SignSO sign)
        {
            AllSOWereGiven?.Invoke(tips, advices, startText, gameOver);
            VillageNamesGiven?.Invoke(name);
            SignSOGiven?.Invoke(sign);
            GameOverSO = gameOver;
        }
    }
}
