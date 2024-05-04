using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthChangedText;

    private Player _player;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.HealthChanged += OnPlayerHealthChanged;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.GoldAmountChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int health)
    {
        _healthChangedText.text = health.ToString();
    }
}
