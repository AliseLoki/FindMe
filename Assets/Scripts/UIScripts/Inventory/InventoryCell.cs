using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _inventoryCellImage;

    public void SetInventoryCellImage(InventoryPrefabSO inventoryPrefabSO)
    {      
        _inventoryCellImage.sprite = inventoryPrefabSO.Sprite;
    }
}
