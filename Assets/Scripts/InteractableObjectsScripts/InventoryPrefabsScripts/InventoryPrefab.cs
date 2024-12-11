using UnityEngine;

namespace Interactables.InventoryPrefabs
{
    public class InventoryPrefab : InteractableObject
    {
        [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;

        public InventoryPrefabSO ConnectedInentoryPrefabSO => _inventoryPrefabSO;

        protected override void UseObject()
        {
            if (PlayerInventory.AddInventoryPrefabSO(_inventoryPrefabSO))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
