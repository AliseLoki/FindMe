using UnityEngine;

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
                foreach (var recipe in _allCuttingRecipesSO)
                {
                    if (recipe.Input == FoodSO)
                    {
                        PlaySoundEffect(AudioClipsList[cuttingSoundEffectIndex]);
                        FoodSO = recipe.Output;
                        Destroy(PlaceForFood.GetChild(0).gameObject);
                        Food = Instantiate(FoodSO.Prefab, PlaceForFood);
                        IsChangedFood = true;
                        TipsViewPanel.ShowBringToCookingTableTip();
                    }
                }
            }
            else
            {
                PlaySoundEffect(AudioClipsList[gettingFoodSoundEffectIndex]);
                Player.PlayerCookingModule.SetFood(Food, FoodSO);
                Player.SetHasSomethingInHands(true);
                ResetFoodAndFoodSO();
                Player.PlayerCookingModule.Food.SetInParent(Player.HandlePoint);
                IsChangedFood = false;
            }
        }
    }

    protected override void PutFood()
    {
        bool hasMatch = false;
        int puttingFoodSoundEffectIndex = 2;

        foreach (var recipe in _allCuttingRecipesSO)
        {
            if (recipe.Input == Player.PlayerCookingModule.FoodSO)
            {
                PlaySoundEffect(AudioClipsList[puttingFoodSoundEffectIndex]);
                FoodSO = Player.PlayerCookingModule.FoodSO;
                Food = FoodSO.Prefab;
                Player.PlayerCookingModule.Food.SetInParent(PlaceForFood);
                Player.PlayerCookingModule.GiveFood();
                TipsViewPanel.ShowCutItTip();
                hasMatch = true;
            }
        }

        if (!hasMatch)
        {
            TipsViewPanel.ShowCantCutItTip();
        }
    }
}
