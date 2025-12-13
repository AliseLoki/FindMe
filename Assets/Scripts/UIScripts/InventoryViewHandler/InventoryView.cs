using GameControllers;
using PlayerController;
using SO;
using UnityEngine;

namespace InventoryViewHandler
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCell _inventoryCell;
        [SerializeField] private Transform _listOfInventoryPrefabImages;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private PlayerOld _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
      
        private void OnEnable()
        {
            _playerInventory.InventoryPrefabSORecieved += OnInventoryPrefabSORecieved;
        }

        private void OnDisable()
        {
            _playerInventory.InventoryPrefabSORecieved -= OnInventoryPrefabSORecieved;
            _inventoryCell.InventoryCellButtonPressed -= OnInventoryCellButtonPressed;
        }

        private void OnInventoryPrefabSORecieved(InventoryPrefabSO inventoryPrefabSO)
        {
            var newInventoryCell = Instantiate(_inventoryCell, _listOfInventoryPrefabImages);
            newInventoryCell.InitLinks(_player, _gameStatesSwitcher);
            newInventoryCell.SetInventoryCellImage(inventoryPrefabSO);
            newInventoryCell.InventoryCellButtonPressed += OnInventoryCellButtonPressed;
        }

        private void OnInventoryCellButtonPressed(InventoryPrefabSO inventoryPrefabSO)
        {
            _playerInventory.RemoveInventoryPrefabSO(inventoryPrefabSO);
        }
    }
}