using TMPro;
using UnityEngine;

public class SettingsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _fullRestartButtonText;

    public void InitButtonText(string text)
    {
        _fullRestartButtonText.text = text;
    }
}
