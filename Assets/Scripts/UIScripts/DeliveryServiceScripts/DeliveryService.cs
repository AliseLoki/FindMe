using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryService : MonoBehaviour
{
    private List<CookingRecipeSO> _orderedDishies = new List<CookingRecipeSO>();
    private List<CookingRecipeSO> _packedDishes = new List<CookingRecipeSO>();

    private MenuSO _menuSO;

    private RecievingOrdersPoint _recievingOrdersPoint;
    private PackingPlace _packingPlace;
    private TipsViewPanel _tipsViewPanel;
    // private DeliveryServiceView _deliveryServiceView;

    public event Action<List<CookingRecipeSO>> OrdersCanBeShown;
    public event Action<CookingRecipeSO> DishHasBeenDelivered;
    public event Action AllDishesHaveBeenDelivered;
    public event Action TimeToGoHasCome;
   
    private void Awake()
    {
        _recievingOrdersPoint = GameManager.Instance.GameEntryPoint.InitRecievingOrdersPoint();
        _packingPlace = GameManager.Instance.GameEntryPoint.InitPackingPlace();
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
        // _deliveryServiceView = GameManager.Instance.GameEntryPoint.InitDeliveryServiceView();
    }


    private void OnEnable()
    {
        _recievingOrdersPoint.OrdersAreTaken += OnOrdersAreTaken;
        _packingPlace.CookingRecipeSOHasBeenPacked += OnCookingRecipeSOHasBeenPacked;
    }

    private void OnDisable()
    {
        _recievingOrdersPoint.OrdersAreTaken -= OnOrdersAreTaken;
        _packingPlace.CookingRecipeSOHasBeenPacked -= OnCookingRecipeSOHasBeenPacked;
    }

    public CookingRecipeSO CheckEquality (CookingRecipeSO cookingRecipeSO)
    {
        foreach (CookingRecipeSO cookingRecipeSOInPackage in _packedDishes)
        {
            if (cookingRecipeSOInPackage.RecipeName == cookingRecipeSO.RecipeName)
            {
              return cookingRecipeSOInPackage;
            }
        }

        return null;
    }

    public void RemoveDeliveredDish(CookingRecipeSO cookingRecipeSO)
    {
        cookingRecipeSO.Readyness = StateOfReadyness.Uncooked;
        _packedDishes.Remove(cookingRecipeSO);
        _orderedDishies.Remove(cookingRecipeSO);
        DishHasBeenDelivered?.Invoke(cookingRecipeSO);
        CheckPackedDishesCount();
    }

    private void CheckPackedDishesCount()
    {
        if(_packedDishes.Count == 0)
        {
            AllDishesHaveBeenDelivered?.Invoke();
        }
    }

    private void OnCookingRecipeSOHasBeenPacked(CookingRecipeSO cookingRecipeSO)
    {
        _packedDishes.Add(cookingRecipeSO);

        if (CheckIfOrdersAndPakcedDishesAreEqual())
        {
            _tipsViewPanel.ShowNoPlaceTip();
        }
    }

    private bool CheckIfOrdersAndPakcedDishesAreEqual()
    {
        if (_packedDishes.Count == _orderedDishies.Count)
        {
            TimeToGoHasCome?.Invoke();
            return true;
        }

        return false;
    }

    private void OnOrdersAreTaken(MenuSO menuSO)
    {
        _menuSO = menuSO;
        TakeOrders();
        OrdersCanBeShown?.Invoke(_orderedDishies);
    }

    private void TakeOrders()
    {
        for (int i = 0; i < _menuSO.MenuList.Count; i++)
        {
            CookingRecipeSO cookingRecipeSO = _menuSO.MenuList[i];
            _orderedDishies.Add(cookingRecipeSO);
        }
    }
}
