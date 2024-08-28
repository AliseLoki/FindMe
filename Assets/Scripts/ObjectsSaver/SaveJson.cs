using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveJson 
{
    public List<InventoryPrefabSO> SavedInventoryListJson =  new();
    public List<CookingRecipeSO> SavedOrderedDishesListJson = new();
    public List<CookingRecipeSO> SavedPackedDishesListJson = new();

    public Transform SavedPlayerPositionToJson;
}


