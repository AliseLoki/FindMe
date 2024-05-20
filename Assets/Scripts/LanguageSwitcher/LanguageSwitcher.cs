using System;
using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
    private string _currentLanguage;

    private const string english = "english";
    private const string russian = "russian";
    private const string turkish = "turkish";

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

    public event Action<TipsSO, EducationAdvicesSO, FirstStartTextSO> AllSOWereGiven;
    public event Action<VillageNamesSO> VillageNamesGiven;
    public event Action<SignSO> SignSOGiven;

    private void Awake()
    {
        //берется из внешнего метода язык
        InitCurrentLanguage(turkish);
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
        if (_currentLanguage == english)
        {
            AllSOWereGiven?.Invoke(_englishTipsSO, _englishEducationAdvicesSO, _englishFirstStartTextSO);
            VillageNamesGiven?.Invoke(_englishVillageNamesSO);
            SignSOGiven?.Invoke(_englishSignSO);
        }
        else if (_currentLanguage == russian)
        {
            AllSOWereGiven?.Invoke(_russianTipsSO, _russianEducationAdvicesSO, _russianFirstStartTextSO);
            VillageNamesGiven?.Invoke(_russianVillageNamesSO);
            SignSOGiven?.Invoke(_russianSignSO);
        }
        else if (_currentLanguage == turkish)
        {
            AllSOWereGiven?.Invoke(_turkishTipsSO, _turkishEducationAdvicesSO, _turkishFirstStartTextSO);
            VillageNamesGiven?.Invoke(_turkishVillageNamesSO);
            SignSOGiven?.Invoke(_turkishSignSO);
        }
    }
}
