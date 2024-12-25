using UnityEngine;
using SO;

namespace Interactables.Containers.Tables
{
    public class CuttingTable : Table
    {
        [SerializeField] private ChangingFoodRecipeSO[] _allCuttingRecipesSO;

        protected override void DoSomething()
        {
            int cuttingSoundEffectIndex = 0;
            int gettingFoodSoundEffectIndex = 1;

            if (Input.GetMouseButtonDown(0))
            {
                if (!IsChangedFood)
                {
                    CutFood(cuttingSoundEffectIndex);
                }
                else
                {
                    TakeChoppedFood(gettingFoodSoundEffectIndex);
                }
            }
        }

        protected override void PutFood()
        {
            bool hasMatch = false;
            int puttingFoodSoundEffectIndex = 2;

            CheckIfCanBeCut(hasMatch, puttingFoodSoundEffectIndex);

            if (!hasMatch)
            {
                TipsViewPanel.ShowCantCutItTip();
            }
        }

        private void TakeChoppedFood(int gettingFoodSoundEffectIndex)
        {
            Player.PlayerCookingModule.SetFood(Food, FoodSO);
            Player.PlayerHands.TakeObject(Food.gameObject, Food.ConnectedFoodSO.Type);
            ResetFoodAndFoodSO();
            IsChangedFood = false;
            PlaySoundEffect(AudioClipsList[gettingFoodSoundEffectIndex]);
        }

        private void CutFood(int cuttingSoundEffectIndex)
        {
            foreach (var recipe in _allCuttingRecipesSO)
            {
                if (recipe.Input == FoodSO)
                {
                    FoodSO = recipe.Output;
                    Destroy(PlaceForFood.GetChild(0).gameObject);
                    Food = Instantiate(FoodSO.Prefab, PlaceForFood).GetComponent<Food>();
                    IsChangedFood = true;
                    TipsViewPanel.ShowBringToCookingTableTip();
                    PlaySoundEffect(AudioClipsList[cuttingSoundEffectIndex]);
                }
            }
        }

        private void CheckIfCanBeCut(bool hasMatch, int puttingFoodSoundEffectIndex)
        {
            foreach (var recipe in _allCuttingRecipesSO)
            {
                if (recipe.Input == Player.PlayerCookingModule.FoodSO)
                {
                    FoodSO = Player.PlayerCookingModule.FoodSO;
                    Food = FoodSO.Prefab.GetComponent<Food>();
                    Player.PlayerCookingModule.Food.SetInParent(PlaceForFood);
                    Player.PlayerCookingModule.GiveFood();
                    Player.PlayerHands.GiveObject();
                    PlaySoundEffect(AudioClipsList[puttingFoodSoundEffectIndex]);
                    TipsViewPanel.ShowCutItTip();
                    hasMatch = true;
                }
            }
        }
    }
}
