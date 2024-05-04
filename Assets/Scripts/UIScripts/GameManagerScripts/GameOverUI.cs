using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
        HideGameOver();
    }

    private void OnGameStateChanged()
    {
        if (GameManager.Instance.IsGameOver())
        {
            ShowGameOver();
        }
        else
        {
            HideGameOver();
        }
    }

    private void ShowGameOver()
    {
        gameObject.SetActive(true);
    }

    private void HideGameOver()
    {
        gameObject.SetActive(false);
    }
}
