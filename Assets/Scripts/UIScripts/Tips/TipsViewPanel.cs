using TMPro;
using UnityEngine;

public class TipsViewPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tipsText;
    [SerializeField] private TipsSO _tipsSO;

    private void OnEnable()
    {
        ShowYouAreSafeTip();
    }

    public void ShowTakeMeTip()
    {
        ShowTips(_tipsSO.TakeMeTip);
    }

    public void ShowEatMeTip()
    {
        ShowTips(_tipsSO.EatMeTip);
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
        ShowTips(_tipsSO.ThisIsPackingPlaceTip);
    }

    public void ShowThisISOvenTip()
    {
        ShowTips(_tipsSO.ThisIsOvenTip);
    }

    public void ShowThisIsCookingTableTip()
    {
        ShowTips(_tipsSO.ThisIsCookingTableTip);
    }

    public void ShowFirstCutItTip()
    {
        ShowTips(_tipsSO.FirstCutItTip);
    }

    public void ShowThisIsCuttingTableTip()
    {
        ShowTips(_tipsSO.ThisIsCuttingTableTip);
    }

    public void ShowThisIsGarbageTip()
    {
        ShowTips(_tipsSO.ThisIsGarbageTip);
    }

    public void ShowThisIsContainerTip()
    {
        ShowTips(_tipsSO.ThisIsContainerTip);
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

    public void ShowDishIssPackedTip()
    {
        ShowTips(_tipsSO.DishIsPackedTip);
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

    public void ShowNothingInHandsTip()
    {
        ShowTips(_tipsSO.NothingInHandsTip);
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

    public void ShowThisIsRecievingOrdersPointTip()
    {
        ShowTips(_tipsSO.ThisIsRecievingOrdersPointTip);
    }

    public void ShowThisIsHouseTip()
    {
        ShowTips(_tipsSO.ThisIsHouseTip);
    }

    public void ShowDishIsPreparedBadlyTip()
    {
        ShowTips(_tipsSO.DishIsPreparedBadly);
    }

    private void ShowTips(string tips)
    {
        _tipsText.text = tips;
    }
}
