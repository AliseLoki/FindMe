using TMPro;
using UnityEngine;

public class TipsViewPanel : MonoBehaviour
{
    public static TipsViewPanel Instance { get; private set; }

    [SerializeField] private TMP_Text _tipsText;
    [SerializeField] private TipsSO _tipsSO;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowBringToCookingTableTip()
    {
        ShowTips(_tipsSO.BringToCookingTableTip);
    }

    public void ShowCutItTip()
    {
        ShowTips(_tipsSO.CutItTip);
    }

    public void ShowCantCutTip()
    {
        ShowTips(_tipsSO.CantCutTip);
    }

    public void ShowNothingToThrowTip()
    {
        ShowTips(_tipsSO.NothingToThrowTip);
    }

    public void ShowThrowFoodTip()
    {
        ShowTips(_tipsSO.ThrowFoodTip);
    }

    public void ShowFoodPickedTip()
    {
        ShowTips(_tipsSO.FoodPickedTip);
    }

    public void ShowHandsAreFullTip()
    {
        ShowTips(_tipsSO.HandsAreFullTip);
    }

    public void ShowTapTheObjectTip()
    {
        ShowTips(_tipsSO.TapTheObjectTip);
    }

    public void ShowApproachTip()
    {
        ShowTips(_tipsSO.ApproachObjectForInteractionTip);
    }

    private void ShowTips(string tips)
    {
        _tipsText.text = tips;
    }
}
