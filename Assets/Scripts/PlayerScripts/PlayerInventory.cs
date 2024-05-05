using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryPrefabSO> _recievedInventoryPrefabsSO;

    private int _maxCells = 6;

    public event Action<InventoryPrefabSO> InventoryPrefabSORecieved;

    private void Awake()
    {
        _recievedInventoryPrefabsSO = new List<InventoryPrefabSO>();
    }

    public bool AddInventoryPrefabSO(InventoryPrefabSO inventoryPrefabSO)
    {
        if (_recievedInventoryPrefabsSO.Count < _maxCells)
        {
            _recievedInventoryPrefabsSO.Add(inventoryPrefabSO);
            InventoryPrefabSORecieved?.Invoke(inventoryPrefabSO);
            return true;
        }

        return false;
    }
}
