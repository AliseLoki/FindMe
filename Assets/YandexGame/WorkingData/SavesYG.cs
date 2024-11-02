
using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

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

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
