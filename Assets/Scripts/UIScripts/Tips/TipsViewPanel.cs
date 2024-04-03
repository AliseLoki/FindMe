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

    private void OnEnable()
    {
        ShowYouAreSafeTip();
    }

    public void ShowYouAreSafeTip()
    {
        ShowTips(_tipsSO.YouAreSafeTip);
    }


    public void ShowYouAreNotSafeTip()
    {
        ShowTips(_tipsSO.YouAreNotSafeTip);
    }

    public void ShowThisIsPackingPlaceTip()
    {
        ShowTips(_tipsSO.ThisIsPackingPlace);
    }

    public void ShowThisISOvenTip()
    {
        ShowTips(_tipsSO.ThisIsOvenTip);
    }

    public void ShowThisIsCookingTableTip()
    {
        ShowTips(_tipsSO.ThisIsCookingTableTip);
    }

    public void ShowThisIsCuttingTableTip()
    {
        ShowTips(_tipsSO.ThisIsCuttingTableTip);
    }

    public void ShowThisIsGarbageTip()
    {
        ShowTips(_tipsSO.ThisIsGarbageTip);
    }

    public void ShowTakeBackpackTip()
    {
        ShowTips(_tipsSO.TakeBackpackTip);
    }

    public void ShowPutWoodInOvenTip()
    {
        ShowTips(_tipsSO.PutWoodInOvenTip);
    }

    public void ShowNoPlaceTip()
    {
        ShowTips(_tipsSO.NoPlaceTip);
    }

    public void ShowRecipesTip()
    {
        ShowTips(_tipsSO.ShowRecipesTip);
    }

    public void ShowCanCookTip()
    {
        ShowTips(_tipsSO.CanCookTip);
    }

    public void EraseTip()
    {
        ShowTips(string.Empty);
    }

    public void ShowBringToOvenTip()
    {
        ShowTips(_tipsSO.BringToOvenTip);
    }

    public void ShowTimeToPack()
    {
        ShowTips(_tipsSO.TimeToPack);
    }

    public void ShowReadynessInstruction()
    {
        ShowTips(_tipsSO.ReadynessInstruction);
    }

    public void ShowCanUseOvenTip()
    {
        ShowTips(_tipsSO.CanUseOvenTip);
    }

    public void ShowCantLightFire()
    {
        ShowTips(_tipsSO.CantLightFireTip);
    }

    public void ShowNoWoodsTip()
    {
        ShowTips(_tipsSO.NoWoodsTip);
    }

    public void ShowBringToCookingTableTip()
    {
        ShowTips(_tipsSO.BringToCookingTableTip);
    }

    public void ShowCantCutItTip()
    {
        ShowTips(_tipsSO.CantCutItTip);
    }

    public void ShowCutItTip()
    {
        ShowTips(_tipsSO.CutItTip);
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
