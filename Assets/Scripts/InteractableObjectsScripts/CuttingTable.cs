using UnityEngine;

public class CuttingTable : Table
{
    [SerializeField] private CuttingRecipeSO[] _allCuttingRecipes;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isChangedFood)
            {
                foreach (var recipe in _allCuttingRecipes)
                {
                    if (recipe.Input == _foodOnTheTableSO)
                    {
                      //  print("пора резать продукты");
                        _foodOnTheTableSO = recipe.Output;
                        Destroy(_placeForFood.GetChild(0).gameObject);
                        _food = Instantiate(_foodOnTheTableSO.Prefab, _placeForFood);
                        _isChangedFood = true;                    
                    }
                }
            }
            else
            {
                Player.Instance.SetFood(_food, _foodOnTheTableSO);
                Player.Instance.SetHasSomethingInHands(true);
                _food = null;
                _foodOnTheTableSO = null;
                Player.Instance.FoodInHands.SetInParent(Player.Instance.HandlePoint);
               // print("взяли порезанный продукт");
                _isChangedFood = false;
            }
        }
    }

    protected override void PutFoodOnTheTable()
    {
        foreach (var recipe in _allCuttingRecipes)
        {
            if (recipe.Input == Player.Instance.FoodInHandsSO)
            {
               // print("put on the table");
                _foodOnTheTableSO = Player.Instance.FoodInHandsSO;
                _food = _foodOnTheTableSO.Prefab;
                Player.Instance.FoodInHands.SetInParent(_placeForFood);
                Player.Instance.GiveFood();
            }
        }
    }
}
