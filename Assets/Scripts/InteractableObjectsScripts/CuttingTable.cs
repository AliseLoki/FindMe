using UnityEngine;

public class CuttingTable : Table
{
    [SerializeField] private ChangingFoodRecipeSO[] _allCuttingRecipesSO;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsChangedFood)
            {
                foreach (var recipe in _allCuttingRecipesSO)
                {
                    if (recipe.Input == FoodSO)
                    {
                        FoodSO = recipe.Output;
                        Destroy(PlaceForFood.GetChild(0).gameObject);
                        Food = Instantiate(FoodSO.Prefab, PlaceForFood);
                        IsChangedFood = true;
                        SoundEffects.PlayCuttingFoodSoundEffect(transform);
                        TipsViewPanel.ShowBringToCookingTableTip();
                    }
                }
            }
            else
            {
                Player.PlayerCookingModule.SetFood(Food, FoodSO);
                Player.SetHasSomethingInHands(true);
                ResetFoodAndFoodSO();
                Player.PlayerCookingModule.Food.SetInParent(Player.HandlePoint);
                IsChangedFood = false;
                SoundEffects.PlayGettingFoodSoundEffect(transform);
            }
        }
    }

    protected override void PutFood()
    {
        bool hasMatch = false;

        foreach (var recipe in _allCuttingRecipesSO)
        {
            if (recipe.Input == Player.PlayerCookingModule.FoodSO)
            {
                FoodSO = Player.PlayerCookingModule.FoodSO;
                Food = FoodSO.Prefab;
                Player.PlayerCookingModule.Food.SetInParent(PlaceForFood);
                Player.PlayerCookingModule.GiveFood();
                SoundEffects.PlayPuttingFoodSoundEffect(transform);
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
