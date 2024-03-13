using System.Collections.Generic;
using UnityEngine;

public enum StateOfReadyness
{
    Uncooked,
    Cooked,
    Burned
}

public class DeliveryService : MonoBehaviour
{
    public static DeliveryService Instance { get; private set; }

    [SerializeField] private MenuSO _menuSO;

    private int _maxOrderedDishies = 7;
    private List<CookingRecipeSO> _orderedDishies;

    private void Awake()
    {
        Instance = this;
        _orderedDishies = new List<CookingRecipeSO>();
        TakeOrders();
    }

    public List<CookingRecipeSO> GetOrderedDishiesList()
    {
        return _orderedDishies;
    }

    private void TakeOrders()
    {
        //for (int i = 0; i < _maxOrderedDishies; i++)
        //{
        //    CookingRecipeSO cookingRecipeSO = _menuSO.MenuList[Random.Range(0, _menuSO.MenuList.Count)];
        //    if (!_orderedDishies.Contains(cookingRecipeSO))
        //    {
        //        _orderedDishies.Add(cookingRecipeSO);
        //    }
        //}

        for (int i = 0; i < _menuSO.MenuList.Count; i++)
        {
            CookingRecipeSO cookingRecipeSO = _menuSO.MenuList[i];
            _orderedDishies.Add(cookingRecipeSO);
        }
    }
}
