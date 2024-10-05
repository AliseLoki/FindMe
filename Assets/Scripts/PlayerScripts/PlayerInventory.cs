using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryPrefabSO> _recievedInventoryPrefabsSO;
    
    [SerializeField] private Player _player;
    [SerializeField] private Saver _saver;

    private int _maxCells = 5;

    public event Action<InventoryPrefabSO> InventoryPrefabSORecieved;
   
    public event Action UsedSpeedBoost;

    private void Awake()
    {
        _recievedInventoryPrefabsSO = _saver.LoadInventory();
    }

    public List<InventoryPrefabSO> GetRecievedInventoryPrefabSOList()
    {
        return _recievedInventoryPrefabsSO;
    }

    public bool AddInventoryPrefabSO(InventoryPrefabSO inventoryPrefabSO)
    {
        if (_recievedInventoryPrefabsSO.Count < _maxCells)
        {
            _player.PlayerSoundEffects.PlayTakingInventoryPrefabSoundEffect();

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
            _player.PlayerEventsHandler.OnHealthChanged(mushroomHealing);
        }
        else if (inventoryPrefabSO.InventoryPrefab as GoldMushroom)
        {
            UsedSpeedBoost?.Invoke();
        }
        else
        {
            _player.PlayerHands.TakeInvenoryPrefabInHands(inventoryPrefabSO);
        }

        _recievedInventoryPrefabsSO.Remove(inventoryPrefabSO);
    }
}


