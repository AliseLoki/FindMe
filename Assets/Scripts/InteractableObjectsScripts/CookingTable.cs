using System;
using System.Collections.Generic;
using UnityEngine;

public class CookingTable : Table
{
    [SerializeField] private ChangingFoodRecipeSO[] _ingredientsForCooking;
    [SerializeField] private Food[] _tableFoodPrefabs;
   // [SerializeField] private List<FoodSO> _setToTheTableFoodSO;
   //// [SerializeField] private Food _unCookedPot;
   // [SerializeField] private CookingRecipeSO _uncookedFoodInPotRecipe;

   private DeliveryService _deliveryService;

   // public event Action<CookingRecipeSO> CanBeCooked;

    private void Awake()
    {
       _deliveryService = GameManager.Instance.GameEntryPoint.InitDeliveryService();
    }

    protected override void DoSomething()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    GivePotToPlayer();
        //    ResetFoodAndFoodSO();
        //    CheckIfCanCook();
        //    Player.PlayerCookingModule.SetCookingRecipe(_uncookedFoodInPotRecipe);
        //}
    }

    //public void PrepareDish(CookingRecipeSO cookingRecipeSO)
    //{
    //    if (Food == null)
    //    {
    //        SpawnPotOnTheTable();
    //    }

    //    _uncookedFoodInPotRecipe = cookingRecipeSO;
    //    HideFoodOnTheTable(cookingRecipeSO);
    //}

    protected override void PutFood()
    {
        TipsViewPanel.ShowRecipesTip();

        foreach (ChangingFoodRecipeSO cuttingRecipeSO in _ingredientsForCooking)
        {
            if (cuttingRecipeSO.Output == Player.PlayerCookingModule.FoodSO)
            {
                ShowFoodOnTheTable();
                //CheckIfHasSameFood(Player.PlayerCookingModule.FoodSO);
                Player.PlayerCookingModule.ThrowFood();
                SoundEffects.PlayPuttingFoodSoundEffect(transform);
            }
        }

       // CheckIfCanCook();
    }

    //private void GivePotToPlayer()
    //{
    //    Player.PlayerCookingModule.SetFood(Food, FoodSO);
    //    Player.SetHasSomethingInHands(true);
    //    Player.PlayerCookingModule.Food.SetInParent(Player.HandlePoint);
    //    SoundEffects.PlayGettingFoodSoundEffect(transform);
    //}

    private void SpawnPotOnTheTable()
    {
        //Food pot = Instantiate(_unCookedPot, PlaceForFood.position, Quaternion.identity);
        //Food = pot;
        //FoodSO = pot.ConnectedFoodSO;
        //TipsViewPanel.ShowBringToOvenTip();
    }

    private void ShowFoodOnTheTable()
    {
        foreach (Food food in _tableFoodPrefabs)
        {
            if (food.ConnectedFoodSO == Player.PlayerCookingModule.FoodSO)
            {
                food.gameObject.SetActive(true);
            }
        }
    }

    //private void HideFoodOnTheTable(CookingRecipeSO cookingRecipeSO)
    //{
    //    foreach (Food food in _tableFoodPrefabs)
    //    {
    //        foreach (var item in cookingRecipeSO.IngredientsForRecipe)
    //        {
    //            if (food.ConnectedFoodSO == item)
    //            {
    //                food.gameObject.SetActive(false);
    //                _setToTheTableFoodSO.Remove(item);
    //            }
    //        }
    //    }
    //}

    //private void CheckIfCanCook()
    //{
    //    foreach (CookingRecipeSO cookingRecipeSO in _deliveryService.GetOrderedDishiesList())
    //    {
    //        if (CheckIfEqual(cookingRecipeSO.IngredientsForRecipe, _setToTheTableFoodSO))
    //        {
    //            CanBeCooked?.Invoke(cookingRecipeSO);
    //        }
    //    }
    //}

    //private void CheckIfHasSameFood(FoodSO playerFoodSO)
    //{
    //    if (!_setToTheTableFoodSO.Contains(playerFoodSO))
    //    {
    //        _setToTheTableFoodSO.Add(playerFoodSO);
    //    }
    //}


    //private bool CheckIfEqual(List<FoodSO> ingredientsInRecipe, List<FoodSO> ingredientsOnTheTable)
    //{
    //    bool isEqual = true;

    //    foreach (var element in ingredientsInRecipe)
    //    {
    //        if (!ingredientsOnTheTable.Contains(element))
    //        {
    //            isEqual = false;
    //            break;
    //        }
    //    }
    //    return isEqual;
    //}
}
