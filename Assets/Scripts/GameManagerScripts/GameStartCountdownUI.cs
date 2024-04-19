using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _countdownText;

    private void Start()
    {
        GameManager.Instance.GameStateChanged += OnGameStateChanged;
        HideCountdown();
    }

    private void Update()
    {
        _countdownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void OnGameStateChanged()
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            ShowCountdown();
        }
        else
        {
            HideCountdown();
        }
    }

    private void ShowCountdown()
    {
       gameObject.SetActive(true);
    }

    private void HideCountdown()
    {
        gameObject.SetActive(false);
    }
}
