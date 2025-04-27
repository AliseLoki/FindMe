using SO;
using System;
using System.Collections.Generic;
using UnityEngine;
using Indexies;

namespace PlayerController
{
    [RequireComponent(typeof(Player))]
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<InventoryPrefabSO> _recievedInventoryPrefabsSO;

        [SerializeField] private Player _player;

        private int _maxCells = 5;

        public event Action<InventoryPrefabSO> InventoryPrefabSORecieved;

        public event Action UsedSpeedBoost;

        public List<InventoryPrefabSO> RecievedInventoryPrefabSO => _recievedInventoryPrefabsSO;

        public void GetInventoryList(List<InventoryPrefabSO> inventoryList)
        {
            _recievedInventoryPrefabsSO = inventoryList;

            foreach (var item in _recievedInventoryPrefabsSO)
            {
                InventoryPrefabSORecieved?.Invoke(item);
            }
        }

        public bool AddInventoryPrefabSO(InventoryPrefabSO inventoryPrefabSO)
        {
            if (_recievedInventoryPrefabsSO.Count < _maxCells)
            {
                _player.PlayerSoundEffects.PlaySoundEffect(inventoryPrefabSO.InventoryPrefab.Clip);
                _recievedInventoryPrefabsSO.Add(inventoryPrefabSO);
                InventoryPrefabSORecieved?.Invoke(inventoryPrefabSO);
                return true;
            }

            return false;
        }

        public void RemoveInventoryPrefabSO(InventoryPrefabSO inventoryPrefabSO)
        {
            if (inventoryPrefabSO.InventoryPrefab.Type == InventoryPrefabType.RedMushroom)
            {
                int mushroomHealing = 1;
                _player.PlayerHealth.ChangeHealthValue(mushroomHealing);
            }
            else if (inventoryPrefabSO.InventoryPrefab.Type == InventoryPrefabType.GoldMushroom)
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
}