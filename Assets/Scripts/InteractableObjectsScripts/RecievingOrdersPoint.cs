using System;
using System.Collections.Generic;
using UnityEngine;

public class RecievingOrdersPoint : InteractableObject
{
    [SerializeField] private List<MenuSO> _allMenusSO;

    private bool _orderIsTaken;

    public event Action<MenuSO> OrdersAreTaken;

    private void OnEnable()
    {
        DeliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }
    private void OnDisable()
    {
        DeliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
    }

    private void OnAllDishesHaveBeenDelivered()
    {
        _orderIsTaken = false;
    }

    protected override void UseObject()
    {
        if (!_orderIsTaken)//временная заглушка
        {
            if (GameManager.Instance.IsEducationPlaying())
            {
                OrdersAreTaken?.Invoke(_allMenusSO[0]);
            }
            else if (GameManager.Instance.IsGamePlaying())
            {
                OrdersAreTaken?.Invoke(_allMenusSO[1]);
            }

            _orderIsTaken = true;
       }
    }
}
