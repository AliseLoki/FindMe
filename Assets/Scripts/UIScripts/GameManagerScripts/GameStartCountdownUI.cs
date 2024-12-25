using TMPro;
using UnityEngine;
using SO;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _countdownText;
    
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private FirstStartTextSO _firstStartTextSO;

    private void Update()
    {     
            CountdownToStart();
    }

    public void InitText(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
    }

    private void CountdownToStart()
    {
        _countdownText.text = Mathf.Ceil(_gameStatesSwitcher.GetCountdownToStartTimer()).ToString();
    }
}
