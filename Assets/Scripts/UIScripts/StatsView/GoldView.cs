using PlayerController;
using TMPro;
using UnityEngine;

namespace StatsView
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _goldAmountText;

        [SerializeField] private PlayerOld _player;

        private void OnEnable()
        {
            _player.PlayerGold.GoldAmountChanged += OnGoldAmountChanged;
        }

        private void OnDisable()
        {
            _player.PlayerGold.GoldAmountChanged -= OnGoldAmountChanged;
        }

        private void OnGoldAmountChanged(int gold)
        {
            _goldAmountText.text = gold.ToString();
        }
    }
}