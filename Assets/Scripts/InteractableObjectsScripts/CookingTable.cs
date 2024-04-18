using System;
using System.Collections.Generic;
using UnityEngine;

public class CookingTable : Table
{
    [SerializeField] private ChangingFoodRecipeSO[] _ingredientsForCooking;
    [SerializeField] private Food[] _tableFoodPrefabs;
    [SerializeField] private List<FoodSO> _setToTheTableFoodSO;
    [SerializeField] private Food _unCookedPot;
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private CookingRecipeSO _uncookedFoodInPotRecipe;

    public event Action<CookingRecipeSO> CanBeCooked;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GivePotToPlayer();
            ResetFoodAndFoodSO();
            CheckIfCanCook();
            Player1.SetCookingRecipe(_uncookedFoodInPotRecipe);
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
        TipsViewPanel.Instance.ShowRecipesTip();

        foreach (ChangingFoodRecipeSO cuttingRecipeSO in _ingredientsForCooking)
        {
            if (cuttingRecipeSO.Output == Player1.FoodInHandsSO)
            {
                ShowFoodOnTheTable();
                CheckIfHasSameFood(Player1.FoodInHandsSO);
                Player1.ThrowFood();
                _soundEffects.PlayPuttingFoodSoundEffect(transform);
            }
        }

        CheckIfCanCook();
    }

    private void GivePotToPlayer()
    {
        Player1.SetFood(_food, FoodOnTheTableSO);
        Player1.SetHasSomethingInHands(true);
        Player1.FoodInHands.SetInParent(Player1.HandlePoint);
        _soundEffects.PlayGettingFoodSoundEffect(transform);
    }

    private void SpawnPotOnTheTable()
    {
        Food pot = Instantiate(_unCookedPot, _placeForFood.position, Quaternion.identity);
        _food = pot;
        FoodOnTheTableSO = pot.ConnectedFoodSO;
        TipsViewPanel.Instance.ShowBringToOvenTip();
    }

    private void ShowFoodOnTheTable()
    {
        foreach (Food food in _tableFoodPrefabs)
        {
            if (food.ConnectedFoodSO == Player1.FoodInHandsSO)
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
