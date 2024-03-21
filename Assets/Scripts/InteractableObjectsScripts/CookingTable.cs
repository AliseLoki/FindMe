using System;
using System.Collections.Generic;
using UnityEngine;

public class CookingTable : Table
{
    [SerializeField] private ChangingFoodRecipeSO[] _ingredientsForCooking;
    [SerializeField] private Food[] _tableFoodPrefabs;
    [SerializeField] private List<FoodSO> _setToTheTableFoodSO;
    [SerializeField] private Food _unCookedPot;

    [SerializeField] private CookingRecipeSO _uncookedFoodInPotRecipe;

    public event Action<CookingRecipeSO> CanBeCooked;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GivePotToPlayer();
            ResetFoodAndFoodSO();
            CheckIfCanCook();
            Player.Instance.SetCookingRecipe(_uncookedFoodInPotRecipe);
        }
    }

    public void PrepareDish(CookingRecipeSO cookingRecipeSO)
    {
        if (_food == null)
        {
            SpawnPotOnTheTable();
        }

        _uncookedFoodInPotRecipe = cookingRecipeSO;
        HideFoodOnTheTable(cookingRecipeSO);
    }

    protected override void PutFood()
    {
        foreach (ChangingFoodRecipeSO cuttingRecipeSO in _ingredientsForCooking)
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

    private void GivePotToPlayer()
    {
        Player.Instance.SetFood(_food, FoodOnTheTableSO);
        Player.Instance.SetHasSomethingInHands(true);
        Player.Instance.FoodInHands.SetInParent(Player.Instance.HandlePoint);
    }

    private void SpawnPotOnTheTable()
    {
        Food pot = Instantiate(_unCookedPot, _placeForFood.position, Quaternion.identity);
        _food = pot;
        FoodOnTheTableSO = pot.ConnectedFoodSO;
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
                    _setToTheTableFoodSO.Remove(item);
                }
            }
        }
    }

    private void CheckIfCanCook()
    {
        foreach (CookingRecipeSO cookingRecipeSO in DeliveryService.Instance.GetOrderedDishiesList())
        {
            if (CheckIfEqual(cookingRecipeSO.IngredientsForRecipe, _setToTheTableFoodSO))
            {
                CanBeCooked?.Invoke(cookingRecipeSO);
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
