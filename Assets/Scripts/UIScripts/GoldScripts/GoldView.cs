using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldAmountText;

    private Player _player;

    private void Awake()
    {
        _player = GameManager.Instance.InitPlayer();
    }

    private void OnEnable()
    {
       _player.PlayerEventsHandler.GoldAmountChanged += OnGoldAmountChanged;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnGoldAmountChanged(int gold)
    {
        _goldAmountText.text = gold.ToString();
    }
}
