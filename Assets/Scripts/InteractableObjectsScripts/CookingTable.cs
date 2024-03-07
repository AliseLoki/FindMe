using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CookingTable : Table
{
    [SerializeField] private CuttingRecipeSO[] _ingredientsForCooking;
    [SerializeField] private Food[] _tableFoodPrefabs;
    [SerializeField] private List<FoodSO> _setToTheTableFoodSO;
    [SerializeField] private Food _unCookedPot;

    private CookingRecipeSO _canBeCookedRecipeSO;

    public event Action<CookingRecipeSO> CanBeCooked;
    public event UnityAction<CookingRecipeSO> DishIsPrepared;

    public void CookDishies()
    {
        print("COOOK");
       // SpawnPotOnTheTable();

        CheckIfCanCook();
        DishIsPrepared?.Invoke(_canBeCookedRecipeSO);
        print("why");
        //деактивировать кнопку или поменять у нее спрайт

        // сет нонэктив префабы на столе и ремув их фром зе сетонзетэйблфудсо

        //инстантинировать кастрюлю и поместить ее в фудонзетэйбл запретить взаимодействовать со столом пока там есть кастрюля
        // DishIsPrepared?.Invoke(cookingRecipeSO);
    }

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("пора отнести в печь");
        }
    }

    protected override void PutFoodOnTheTable()
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in _ingredientsForCooking)
        {
            if (cuttingRecipeSO.Output == Player.Instance.FoodInHandsSO)
            {
                ShowFoodOnTheTable();
                CheckIfHasSameFood(Player.Instance.FoodInHandsSO);
                Player.Instance.ThrowFood();
            }
        }

        CheckIfCanCook();
    }

    private void SpawnPotOnTheTable()
    {
        Food pot = Instantiate(_unCookedPot, _placeForFood.position, Quaternion.identity);
    }

    private void ShowFoodOnTheTable()
    {
        foreach (Food food in _tableFoodPrefabs)
        {
            if (food.ConnectedFoodSO == Player.Instance.FoodInHandsSO)
            {
                food.gameObject.SetActive(true);
            }
        }
    }

    private void HideFoodOnTheTable(CookingRecipeSO cookingRecipeSO)
    {
        foreach (Food food in _tableFoodPrefabs)
        {
            foreach (var item in cookingRecipeSO.IngredientsForRecipe)
            {
                if (food.ConnectedFoodSO == item)
                {
                    food.gameObject.SetActive(false);
                }
            }
        }
    }

    private void CheckIfHasSameFood(FoodSO playerFoodSO)
    {
        if (!_setToTheTableFoodSO.Contains(playerFoodSO))
        {
            _setToTheTableFoodSO.Add(playerFoodSO);
        }
    }

    private void CheckIfCanCook()
    {
        foreach (CookingRecipeSO cookingRecipeSO in DeliveryService.Instance.GetOrderedDishiesList())
        {
            if (CheckIfEqual(cookingRecipeSO.IngredientsForRecipe, _setToTheTableFoodSO))
            {
                _canBeCookedRecipeSO = cookingRecipeSO;
                CanBeCooked?.Invoke(cookingRecipeSO);
            }
        }
    }

    private bool CheckIfEqual(List<FoodSO> ingredientsInRecipe, List<FoodSO> ingredientsOnTheTable)
    {
        bool isEqual = true;

        foreach (var element in ingredientsInRecipe)
        {
            if (!ingredientsOnTheTable.Contains(element))
            {
                isEqual = false;
                break;
            }
        }
        return isEqual;
    }
}
