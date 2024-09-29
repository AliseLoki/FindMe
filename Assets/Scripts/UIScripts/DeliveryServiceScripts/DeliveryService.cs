using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryService : MonoBehaviour
{
    [SerializeField] private Saver _saver;
    [SerializeField] private DeliveryServiceView _deliveryServiceView;

    private List<CookingRecipeSO> _orderedDishies = new List<CookingRecipeSO>();
    private List<CookingRecipeSO> _packedDishes = new List<CookingRecipeSO>();

    private MenuSO _menuSO;

    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private PackingPlace _packingPlace;
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    public MenuSO MenuSO => _menuSO;

    public event Action<string, List<CookingRecipeSO>> OrdersCanBeShown;
    public event Action<CookingRecipeSO> DishHasBeenPacked;
    public event Action<CookingRecipeSO> DishHasBeenDelivered;
    public event Action AllDishesHaveBeenDelivered;
    public event Action TimeToGoHasCome;

    private void Start()
    {
        if (_recievingOrdersPoint.OrderIsTaken)
        {
            _orderedDishies = _saver.LoadOrderedDishies();
            _packedDishes = _saver.LoadPackedDishies();
            InitLists();
            SortSavedDishies();
        }
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

    public void InitLists()
    {
        _deliveryServiceView.InitDishesFromSavedList(_orderedDishies);
    }

    public List<CookingRecipeSO> GetOrderedDishiesList()
    {
        return _orderedDishies;
    }

    public List<CookingRecipeSO> GetPackedDishiesList()
    {
        return _packedDishes;
    }

    public CookingRecipeSO CheckEquality(CookingRecipeSO cookingRecipeSO)
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
        if (_packedDishes.Count == 0)
        {
            AllDishesHaveBeenDelivered?.Invoke();
        }
    }

    private void OnCookingRecipeSOHasBeenPacked(CookingRecipeSO cookingRecipeSO)
    {
        DishHasBeenPacked?.Invoke(cookingRecipeSO);
        _packedDishes.Add(cookingRecipeSO);

        if (CheckIfOrdersAndPakcedDishesAreEqual())
        {
            _tipsViewPanel.ShowNoPlaceTip();
        }
    }

    private void SortSavedDishies()
    {
        foreach (CookingRecipeSO recipe in _orderedDishies)
        {
            if (CheckEquality(recipe))
            {
                DishHasBeenPacked?.Invoke(recipe);
            }
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

    private void OnOrdersAreTaken(string destinationPointName, MenuSO menuSO)
    {
        _menuSO = menuSO;
        TakeOrders();
        OrdersCanBeShown?.Invoke(destinationPointName, _orderedDishies);
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
