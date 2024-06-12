using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasUI : MonoBehaviour
{
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
