using TMPro;
using UnityEngine;
using PlayerController;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthChangedText;

    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.PlayerHealth.HealthChanged += OnPlayerHealthChanged;
    }

    private void OnDisable()
    {
        _player.PlayerHealth.HealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int health)
    {
        _healthChangedText.text = health.ToString();
    }
}
