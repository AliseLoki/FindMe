using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerEvents))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryPrefabSO> _recievedInventoryPrefabsSO;
    [SerializeField] private AudioClip _takingInventoryPrefabSoundEffect;
    [SerializeField] private SaveSystem _saveSystem;

    private int _maxCells = 5;
    private PlayerEvents _playerEvents;
    private Player _player;

    public event Action<InventoryPrefabSO> InventoryPrefabSORecieved;
    public event Action UsedSpeedBoost;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerEvents = GetComponent<PlayerEvents>();
       // _recievedInventoryPrefabsSO = new List<InventoryPrefabSO>();
    }

    private void Start()
    {
        _recievedInventoryPrefabsSO = _saveSystem.LoadInventory();     
        //_player.PlayerMovement.Teleport(_saveSystem.LoadPlayerPosition(transform));
        //print(_saveSystem.LoadPlayerPosition(transform).position);
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
            _player.PlaySoundEffect(_takingInventoryPrefabSoundEffect);
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


