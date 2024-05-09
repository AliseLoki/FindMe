using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _inventoryCellImage;

    private InventoryPrefabSO _inventoryPrefabSO;

    public event Action<InventoryPrefabSO> InventoryCellButtonPressed;
  
    public void SetInventoryCellImage(InventoryPrefabSO inventoryPrefabSO)
    {      
        _inventoryCellImage.sprite = inventoryPrefabSO.Sprite;
        _inventoryPrefabSO = inventoryPrefabSO;
    }

    public void OnInventoryCellButtonPressed()
    {
        InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
        RemoveInventoryCell();
    }

    private void RemoveInventoryCell()
    {
        Destroy(this.gameObject,0.5f);
    }
}
