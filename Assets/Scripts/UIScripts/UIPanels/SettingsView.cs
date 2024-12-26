using TMPro;
using UnityEngine;

namespace UIPanels
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fullRestartButtonText;

        public void InitButtonText(string text)
        {
            _fullRestartButtonText.text = text;
        }
    }
}
