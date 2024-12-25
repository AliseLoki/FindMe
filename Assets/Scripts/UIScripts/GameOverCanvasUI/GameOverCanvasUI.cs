using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using SettingsForYG;

public class GameOverCanvasUI : MonoBehaviour
{
    [SerializeField] private bool _hasWin;

    [SerializeField] private TMP_Text _mainText;
    [SerializeField] private TMP_Text _restartButtonText;

    [SerializeField] private LanguageSwitcher _languageSwitcher;

    private void Start()
    {
        ChangeLanguage();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeLanguage()
    {
        if (_hasWin)
        {
            _mainText.text = _languageSwitcher.GameOverSO.VictoryText;
        }
        else
        {
            _mainText.text = _languageSwitcher.GameOverSO.LooseText;
        }

        _restartButtonText.text = _languageSwitcher.GameOverSO.Restart;
    }
}
