using Indexes;
using SO;
using UnityEngine;

namespace Interactables.InventoryPrefabs
{
    public class InventoryPrefab : InteractableObject
    {
        [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;
        [SerializeField] private InventoryPrefabType _type;

        public InventoryPrefabType Type =>_type;
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
