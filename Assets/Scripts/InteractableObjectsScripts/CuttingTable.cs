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
                    }
                }
            }
            else
            {
                Player.Instance.SetFood(_food, FoodOnTheTableSO);
                Player.Instance.SetHasSomethingInHands(true);
                ResetFoodAndFoodSO();
                Player.Instance.FoodInHands.SetInParent(Player.Instance.HandlePoint);
                IsChangedFood = false;
                _soundEffects.PlayGettingFoodSoundEffect(transform);
            }
        }
    }

    protected override void PutFood()
    {
        foreach (var recipe in _allCuttingRecipes)
        {
            if (recipe.Input == Player.Instance.FoodInHandsSO)
            {
                FoodOnTheTableSO = Player.Instance.FoodInHandsSO;
                _food = FoodOnTheTableSO.Prefab;
                Player.Instance.FoodInHands.SetInParent(_placeForFood);
                Player.Instance.GiveFood();
                _soundEffects.PlayPuttingFoodSoundEffect(transform);
            }
        }
    }
}
