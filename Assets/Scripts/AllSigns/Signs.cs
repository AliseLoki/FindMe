using SettingsForYG;
using SO;
using System.Collections.Generic;
using UnityEngine;

namespace AllSigns
{
    public class Signs : MonoBehaviour
    {
        [SerializeField] private List<Sign> _signs;
        [SerializeField] private LanguageSwitcher _languageSwitcher;

        private SignSO _signSO;

        private void OnEnable()
        {
            _languageSwitcher.SignSOGiven += InitSignSO;
        }

        private void OnDisable()
        {
            _languageSwitcher.SignSOGiven -= InitSignSO;
        }

        private void Start()
        {
            InitAllSignsNames();
        }

        private void InitAllSignsNames()
        {
            _signs[0].InitPointerNames(_signSO.FirstSign);
            _signs[1].InitPointerNames(_signSO.SecondSign);
            _signs[2].InitPointerNames(_signSO.ThirdSign);
            _signs[3].InitPointerNames(_signSO.FourthSign);
            _signs[4].InitPointerNames(_signSO.FifthSign);
            _signs[5].InitPointerNames(_signSO.SixthSign);
            _signs[6].InitPointerNames(_signSO.SeventhSign);
            _signs[7].InitPointerNames(_signSO.EighthSign);
            _signs[8].InitPointerNames(_signSO.NinthSign);
            _signs[9].InitPointerNames(_signSO.TenthSign);
            _signs[10].InitPointerNames(_signSO.EleventhSign);
            _signs[11].InitPointerNames(_signSO.TwelfthSign);
        }

        private void InitSignSO(SignSO signSO)
        {
            _signSO = signSO;
        }
    }
}
