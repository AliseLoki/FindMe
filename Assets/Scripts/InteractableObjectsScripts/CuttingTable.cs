using UnityEngine;

public class CuttingTable : Table
{
    [SerializeField] private CuttingRecipeSO[] _allCuttingRecipes;

    private Food _currentFoodPrefab;
    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var recipe in _allCuttingRecipes)
            {
                if (recipe.Input == _foodOnTheTableSO)
                {
                    _currentFoodPrefab = _food;
                    _currentFoodPrefab.transform.SetParent(null);
                    Destroy(_currentFoodPrefab.gameObject);
                    print("пора резать продукты");
                    _foodOnTheTableSO = recipe.Output;
                    _food = Instantiate(_foodOnTheTableSO.Prefab, _placeForFood);                   
                }
            }
        }
    }

    protected override void PutFoodOnTheTable()
    {
        foreach (var recipe in _allCuttingRecipes)
        {
            if (recipe.Input == Player.Instance.FoodInHandsSO)
            {
                print("put on the table");
                _foodOnTheTableSO = Player.Instance.FoodInHandsSO;
                _food = _foodOnTheTableSO.Prefab;
                Player.Instance.FoodInHands.SetInParent(_placeForFood);
                Player.Instance.GiveFood();
            }
        }
    }
}
