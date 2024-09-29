using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] protected FoodSO FoodSO;

    protected Food Food;

    protected override void UseObject()
    {
        int gettingFoodSoundEffectIndex = 0;

        if (!Player.PlayerHands.HasSomethingInHands)
        {
            PlaySoundEffect(AudioClipsList[gettingFoodSoundEffectIndex]);
            Food = Instantiate(FoodSO.Prefab, Player.HandlePoint);
            Player.SetHasSomethingInHands(true);
            Player.PlayerCookingModule.SetFood(Food, FoodSO);
            TipsViewPanel.ShowFoodPickedTip();
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }
}
