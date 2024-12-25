using System.Collections.Generic;
using UnityEngine;
using Indexes;
using SO;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int money = 1;                       
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        public int Gold = 0;
        public int Health = 10;

        public Vector3 PlayerPosition = new Vector3(57, 0, 283);

        public bool IsFirstStart = true;
        public bool HasBackPack = false;

        public HoldableObjectType HoldableObject = 0;

        public List<InventoryPrefabSO> InventoryList = new();

        public bool OrderIsTaken = false;

        public List<CookingRecipeSO> SavedOrderedDishesListJson = new();
        public List<CookingRecipeSO> SavedPackedDishesListJson = new();
        public List<StateOfReadyness> SavedStatesOfReadyness = new(); 

        public string RecipeName = string.Empty;

        public string VillageName = string.Empty;

        public List<ActivableObjectType> ActiveContainers = new();

        public List<ActivableObjectType> ActivePatches = new();

        public List<HouseIndex> HouseIndexes = new();
     
        public List<VillageIndex> VillagesThatGaveReward = new();
        public List<VillageIndex> VillagesWhereRewardIsntPicked = new();

        public SavesYG()
        {
            openLevels[1] = true;
        }
    }
}
