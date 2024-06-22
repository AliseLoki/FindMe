using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _restartButtonText;
  
    private GameOverSO _gameOverSO;

    private void Start()
    {
        InitText();
    }

    public void InitGameOverSO(GameOverSO gameOverSO)
    {
        _gameOverSO = gameOverSO;
    }

    private void InitText()
    {
        _text.text = _gameOverSO.GameOver;
        _restartButtonText.text = _gameOverSO.Restart;
    }
}
