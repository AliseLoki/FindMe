using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryService : MonoBehaviour
{
    public static DeliveryService Instance { get; private set; }

    [SerializeField] private MenuSO _menuSO;

    private int _maxOrderedDishies = 7;
    private List<CookingRecipeSO> _orderedDishies;

    //public event UnityAction DeliveryOrdered;
    //public event UnityAction DeliveryCompleted;

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
        for (int i = 0; i < _maxOrderedDishies; i++)
        {
            CookingRecipeSO cookingRecipeSO = _menuSO.MenuList[Random.Range(0, _menuSO.MenuList.Count)];
            _orderedDishies.Add(cookingRecipeSO);
        }

        //DeliveryOrdered?.Invoke();
    }
}
