using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform _mainMenu;
    [SerializeField] private Transform _settings;

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnSaveButtonPressed()
    {

    }

    public void OnLoadButtonPressed()
    {

    }

    public void OnSettingsButtonPressed()
    {
        _mainMenu.gameObject.SetActive(false);
        _settings.gameObject.SetActive(true);
    }
    
    public void OnBackToMainMenuPressed()
    {
        _mainMenu.gameObject.SetActive(true);
        _settings.gameObject.SetActive(false);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
}
