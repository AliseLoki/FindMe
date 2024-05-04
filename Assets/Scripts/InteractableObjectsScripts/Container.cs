using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] protected FoodSO FoodSO;

    protected Food Food;

    protected override void UseObject()
    {
        if (!Player.HasSomethingInHands)
        {
            Food = Instantiate(FoodSO.Prefab, Player.HandlePoint);
            Player.SetHasSomethingInHands(true);
            Player.PlayerCookingModule.SetFood(Food, FoodSO);
            TipsViewPanel.ShowFoodPickedTip();
            SoundEffects.PlayGettingFoodSoundEffect(transform);
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }
}
