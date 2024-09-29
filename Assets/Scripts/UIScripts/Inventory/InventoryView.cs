using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCell;
    [SerializeField] private Transform _listOfInventoryPrefabImages;

    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Player _player;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    private void Start()
    {
        InitInventoryList(_playerInventory.GetRecievedInventoryPrefabSOList());
    }

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
        newInventoryCell.InitLinks(_player,_gameStatesSwitcher,_tipsViewPanel);
        newInventoryCell.SetInventoryCellImage(inventoryPrefabSO);
        newInventoryCell.InventoryCellButtonPressed += OnInventoryCellButtonPressed;
    }

    private void OnInventoryCellButtonPressed(InventoryPrefabSO inventoryPrefabSO)
    {
        _playerInventory.RemoveInventoryPrefabSO(inventoryPrefabSO);
    }

    private void InitInventoryList(List<InventoryPrefabSO> list)
    {
        foreach (var item in list)
        {
            OnInventoryPrefabSORecieved(item);
        }
    }
}
