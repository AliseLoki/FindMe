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

    public InventoryPrefabSO DisableColliders()
    {
        this.transform.parent = Player.PlayerHands.HandlePoint.transform;
        this.transform.position = Player.PlayerHands.HandlePoint.position;
        GetComponent<Collider>().enabled = false;
        SelectedObject.Hide();
        //Player.PlayerHands.SetHasSomethingInHands(true);
        return _inventoryPrefabSO;
    }
}
