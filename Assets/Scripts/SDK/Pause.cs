using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPaused;

    public void PauseGame()
    {
        if (!_isPaused)
        {
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
            _isPaused = true;
        }
    }

    public void UnpauseGame()
    {
        if (_isPaused)
        {
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
            _isPaused = false;
        }
    }
}
