using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveJson
{
    public List<InventoryPrefabSO> SavedInventoryListJson;
    public List<CookingRecipeSO> SavedOrderedDishesListJson;
    public List<CookingRecipeSO> SavedPackedDishesListJson;

    public List<House> SavedFirstVillageHouses;
    public List<House> SavedSecondVillageHouses;
    public List<House> SavedThirdVillageHouses;
    public List<House> SavedFourthVillageHouses;
    public List<House> SavedFifthVillageHouses;

    public Vector3 SavedPlayerPositionToJson;

    public HoldableObjectType SavedHoldableObject;

    //
    public StateOfReadyness SavedStateOfReadyness;
}


