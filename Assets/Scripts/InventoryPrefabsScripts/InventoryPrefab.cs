using UnityEngine;

public class InventoryPrefab : InteractableObject
{
    [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;

    protected override void UseObject()
    {
        if (PlayerInventory.AddInventoryPrefabSO(_inventoryPrefabSO))
        {
            Destroy(this.gameObject);
        }
    }
}