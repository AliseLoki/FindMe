using UnityEngine;

public class CuttingTable : Table
{
    [SerializeField] private ChangingFoodRecipeSO[] _allCuttingRecipes;
    [SerializeField] private SoundEffects _soundEffects;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsChangedFood)
            {
                foreach (var recipe in _allCuttingRecipes)
                {
                    if (recipe.Input == FoodOnTheTableSO)
                    {
                        FoodOnTheTableSO = recipe.Output;
                        Destroy(_placeForFood.GetChild(0).gameObject);
                        _food = Instantiate(FoodOnTheTableSO.Prefab, _placeForFood);
                        IsChangedFood = true;
                        _soundEffects.PlayCuttingFoodSoundEffect(transform);
                        TipsViewPanel.Instance.ShowBringToCookingTableTip();
                    }
                }
            }
            else
            {
                Player1.SetFood(_food, FoodOnTheTableSO);
                Player1.SetHasSomethingInHands(true);
                ResetFoodAndFoodSO();
                Player1.FoodInHands.SetInParent(Player1.HandlePoint);
                IsChangedFood = false;
                _soundEffects.PlayGettingFoodSoundEffect(transform);
            }
        }
    }

    protected override void PutFood()
    {
        bool hasMatch = false;

        foreach (var recipe in _allCuttingRecipes)
        {
            if (recipe.Input == Player1.FoodInHandsSO)
            {
                FoodOnTheTableSO = Player1.FoodInHandsSO;
                _food = FoodOnTheTableSO.Prefab;
                Player1.FoodInHands.SetInParent(_placeForFood);
                Player1.GiveFood();
                _soundEffects.PlayPuttingFoodSoundEffect(transform);
                TipsViewPanel.Instance.ShowCutItTip();
                hasMatch = true;
            }
        }

        if (!hasMatch)
        {
            TipsViewPanel.Instance.ShowCantCutItTip();
        }
    }
}
