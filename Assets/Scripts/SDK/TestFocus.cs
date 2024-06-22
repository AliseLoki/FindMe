using UnityEngine;
using Agava.WebUtility;

public class TestFocus : MonoBehaviour
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
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    public void MuteAudio(bool value)
    {
        AudioListener.volume = value ? 0 : 1;
    }

    public void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
