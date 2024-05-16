using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCell;
    [SerializeField] private Transform _listOfInventoryPrefabImages;

    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _playerInventory = GameManager.Instance.GameEntryPoint.InitPlayerInventory();
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
        newInventoryCell.SetInventoryCellImage(inventoryPrefabSO);
        newInventoryCell.InventoryCellButtonPressed += OnInventoryCellButtonPressed;
    }

    private void OnInventoryCellButtonPressed(InventoryPrefabSO inventoryPrefabSO)
    {
        _playerInventory.RemoveInventoryPrefabSO(inventoryPrefabSO);
    }
}
