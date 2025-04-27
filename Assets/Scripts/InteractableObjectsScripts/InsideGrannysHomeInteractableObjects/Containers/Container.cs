using SO;
using UnityEngine;

namespace Interactables.Containers
{
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
                //Food newFood = Instantiate(FoodSO.Prefab);

                Player.PlayerHands.TakeObject(spawnedFood.gameObject, spawnedFood.ConnectedFoodSO.Type);

                Player.PlayerCookingModule.SetFood(spawnedFood, FoodSO);
                Player.PlayerSoundEffects.PlaySoundEffect(Clip);
               // TipsViewPanel.ShowFoodPickedTip();

            }
            else
            {
               // TipsViewPanel.ShowHandsAreFullTip();
            }
        }
    }
}
