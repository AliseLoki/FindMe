using Agava.WebUtility;
using UnityEngine;

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
        if (!_canvasUI.IsAdPlaying)
        {
            StopGame(isBackground);
        }
    }

    public void StopGame(bool isPaused)
    {
        if (_isStopped == isPaused) return;

        MuteAudio(isPaused);
        PauseGame(isPaused);
        _isStopped = isPaused;
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
