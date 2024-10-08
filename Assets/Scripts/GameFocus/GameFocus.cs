using UnityEngine;
using YG;

public class GameFocus : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.onShowWindowGame += OnWindowGameOpened;
        YandexGame.onHideWindowGame += OnWindowGameClosed;
    }

    private void OnDisable()
    {
        YandexGame.onShowWindowGame -= OnWindowGameOpened;
        YandexGame.onHideWindowGame -= OnWindowGameClosed;
    }

    private void OnWindowGameOpened()
    {
        StopGame(false);
    }

    private void OnWindowGameClosed()
    {
        StopGame(true);
    }

    private void StopGame(bool isPaused)
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
