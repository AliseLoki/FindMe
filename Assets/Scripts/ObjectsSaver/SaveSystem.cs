using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private DeliveryService _deliveryService;

    private const string SavedInventoryList = nameof(SavedInventoryList);
    private const string SavedOrderedDishes = nameof(SavedOrderedDishes);
    private const string SavedPackedDishes = nameof(SavedPackedDishes);

    private const string SavedPlayerPosition = nameof(SavedPlayerPosition);

    private const string PlayerPrefsOrderIsTaken = nameof(PlayerPrefsOrderIsTaken);
    private const string PlayerPrefsHasWood = nameof(PlayerPrefsHasWood);

    private void OnEnable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone += Save;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone -= Save;
    }

    public List<InventoryPrefabSO> LoadInventory()
    {
        string globalDataJSON = PlayerPrefs.GetString(SavedInventoryList);
        SaveJson loadedList = JsonUtility.FromJson<SaveJson>(globalDataJSON);

        if (loadedList != null)
        {
            return loadedList.SavedInventoryListJson;
        }
        else
        {
            return new List<InventoryPrefabSO>();
        }
    }

    public List<CookingRecipeSO> LoadOrderedDishies()
    {
        string globalDataJSON = PlayerPrefs.GetString(SavedOrderedDishes);
        SaveJson loadedList = JsonUtility.FromJson<SaveJson>(globalDataJSON);

        if (loadedList != null)
        {
            return loadedList.SavedOrderedDishesListJson;
        }
        else
        {
            return new List<CookingRecipeSO>();
        }
    }

    public List<CookingRecipeSO> LoadPackedDishies()
    {
        string globalDataJSON = PlayerPrefs.GetString(SavedPackedDishes);
        SaveJson loadedList = JsonUtility.FromJson<SaveJson>(globalDataJSON);

        if (loadedList != null)
        {
            return loadedList.SavedPackedDishesListJson;
        }
        else
        {
            return new List<CookingRecipeSO>();
        }
    }

    public bool LoadOrderIsTakenState()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsOrderIsTaken, 0));
    }

    public bool LoadHasWood()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasWood, 0));
    }
    //public Transform LoadPlayerPosition(Transform defaultPosition)
    //{
    //    string globalDataJSON = PlayerPrefs.GetString(SavedPlayerPosition);
    //    SaveJson loadedPlayerPosition = JsonUtility.FromJson<SaveJson>(globalDataJSON);

    //    if (loadedPlayerPosition != null)
    //    {
    //        return loadedPlayerPosition.SavedPlayerPositionToJson;
    //    }
    //    else
    //    {
    //        return defaultPosition;
    //    }
    //}

    //private void SavePlayerPosition(Transform playerPositionToSave)
    //{
    //    SaveJson saveJson = new SaveJson();
    //    saveJson.SavedPlayerPositionToJson = playerPositionToSave;

    //    string Json = JsonUtility.ToJson(saveJson);
    //    PlayerPrefs.SetString(SavedPlayerPosition, Json);

    //    Debug.Log(saveJson.SavedPlayerPositionToJson.position);
    //}

    private void SaveLists(List<InventoryPrefabSO> inventoryToSave, List<CookingRecipeSO> orderedDishesToSave, List<CookingRecipeSO> packedDishesToSave)
    {
        var ListInClass = new SaveJson();

        ListInClass.SavedInventoryListJson = inventoryToSave;
        ListInClass.SavedOrderedDishesListJson = orderedDishesToSave;
        ListInClass.SavedPackedDishesListJson = packedDishesToSave;
        var outputString = JsonUtility.ToJson(ListInClass);
        var outputString2 = JsonUtility.ToJson(ListInClass);
        var outputString3 = JsonUtility.ToJson(ListInClass);
        PlayerPrefs.SetString(SavedInventoryList, outputString);
        PlayerPrefs.SetString(SavedOrderedDishes, outputString2);
        PlayerPrefs.SetString(SavedPackedDishes, outputString3);
    }

    //private void SaveLists(List<InventoryPrefabSO> inventoryToSave, List<CookingRecipeSO> orderedDishesToSave, List<CookingRecipeSO> packedDishesToSave)
    //{
    //    var ListInClass = new SaveJson();

    //    //SaveList(ListInClass.SavedInventoryListJson,inventoryToSave,ListInClass,SavedInventoryList);
    //    //SaveList(ListInClass.SavedInventoryListJson,inventoryToSave,ListInClass,SavedInventoryList);
    //    //SaveList(ListInClass.SavedInventoryListJson,inventoryToSave,ListInClass,SavedInventoryList);

    //}

    //private void SaveList(List<object>jsonList,List<object>listToSave,SaveJson saveJson,string constString)
    //{
    //    jsonList = listToSave;
    //    var outputString = JsonUtility.ToJson(saveJson);
    //    PlayerPrefs.SetString(constString, outputString);
    //}

    private void SaveState(string nameOfState, int value)
    {
        PlayerPrefs.SetInt(nameOfState, value);
    }

    private void Save()
    {
        //SavePlayerPosition(_player.transform);
        SaveState(PlayerPrefsOrderIsTaken, ConvertBoolToInt(_recievingOrdersPoint.OrderIsTaken));
        SaveState(PlayerPrefsHasWood,ConvertBoolToInt(_player.HasWood));
        SaveLists(_player.PlayerInventory.GetRecievedInventoryPrefabSOList(), _deliveryService.GetOrderedDishiesList(),
            _deliveryService.GetPackedDishiesList());
    }

    private bool ConvertIntToBool(int value)
    {
        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int ConvertBoolToInt(bool isActive)
    {
        if (isActive == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
