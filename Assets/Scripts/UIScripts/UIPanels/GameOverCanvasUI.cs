using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIPanels
{
    public class GameOverCanvasUI : MonoBehaviour
    {
        public void OnRestartButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}
