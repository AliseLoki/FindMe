using Agava.WebUtility;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;
public class TestFocusForGameOver : MonoBehaviour
{
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        StopGame(isBackground);
    }

    public void StopGame(bool isPaused)
    {
        MuteAudio(isPaused);
        PauseGame(isPaused);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.volume = value ? 0 : 1;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
