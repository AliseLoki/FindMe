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

    private void Start()
    {
        _recievedInventoryPrefabsSO = _saver.LoadInventory();
    }

    public bool CheckIfHasSeeds(InventoryPrefabSO inventoryPrefabSO)
    {
        foreach (var item in _recievedInventoryPrefabsSO)
        {
            if (item == inventoryPrefabSO)
            {
                return true;
            }
        }

        return false;
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
        else if (inventoryPrefabSO.InventoryPrefab as TomatoForSeeds || inventoryPrefabSO.InventoryPrefab as CabbageForSeeds ||
            inventoryPrefabSO.InventoryPrefab as Cow)
        {
            _player.TakeSeedInHands(inventoryPrefabSO);
        }
        else if (inventoryPrefabSO.InventoryPrefab as Sword)
        {
            _player.TakeSwordInHands(inventoryPrefabSO);
        }
        else if (inventoryPrefabSO.InventoryPrefab as Necronomicon)
        {
            _player.TakeNecronomiconInHands(inventoryPrefabSO);
        }

        _recievedInventoryPrefabsSO.Remove(inventoryPrefabSO);
    }
}


