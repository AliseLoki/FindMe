using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEvents))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryPrefabSO> _recievedInventoryPrefabsSO;

    private int _maxCells = 6;
    private PlayerEvents _playerEvents;

    public event Action<InventoryPrefabSO> InventoryPrefabSORecieved;
    public event Action UsedSpeedBoost;

    private void Awake()
    {
        _playerEvents = GetComponent<PlayerEvents>();
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

    public void RemoveInventoryPrefabSO(InventoryPrefabSO inventoryPrefabSO)
    {
        if (inventoryPrefabSO.InventoryPrefab as RedMushroom)
        {
            int mushroomHealing = 1;

            _playerEvents.OnHealthChanged(mushroomHealing);
        }
        else if (inventoryPrefabSO.InventoryPrefab as GoldMushroom)
        {
            UsedSpeedBoost?.Invoke();
        }

        _recievedInventoryPrefabsSO.Remove(inventoryPrefabSO);
    }
}
