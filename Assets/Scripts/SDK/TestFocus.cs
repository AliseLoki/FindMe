using Agava.WebUtility;
using System;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;

public class TestFocus : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;

    private bool _isStopped;

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
        if (_canvasUI.IsAdPlaying && isBackground == false)
        {
            return;
        }

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
