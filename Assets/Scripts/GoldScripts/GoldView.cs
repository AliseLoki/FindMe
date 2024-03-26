using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldAmountText;

    private void OnEnable()
    {
       Player.Instance.GoldAmountChanged += OnGoldAmountChanged;
    }

    private void OnDisable()
    {
        Player.Instance.GoldAmountChanged -= OnGoldAmountChanged;
    }

    private void OnGoldAmountChanged(int gold)
    {
        _goldAmountText.text = gold.ToString();
    }
}
