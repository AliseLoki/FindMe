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
            var spawnedFood = Instantiate(FoodSO.Prefab).GetComponent<Food>();
            Player.PlayerHands.TakeObject(spawnedFood.gameObject, spawnedFood.ConnectedFoodSO.Type);

            Player.PlayerCookingModule.SetFood(spawnedFood, FoodSO);

            TipsViewPanel.ShowFoodPickedTip();
            PlaySoundEffect(AudioClipsList[gettingFoodSoundEffectIndex]);
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }
}
