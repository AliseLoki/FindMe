using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveJson
{
    public List<InventoryPrefabSO> SavedInventoryListJson;
    public List<CookingRecipeSO> SavedOrderedDishesListJson;
    public List<CookingRecipeSO> SavedPackedDishesListJson;

    public Vector3 SavedPlayerPositionToJson;
}


