using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private const string CameraZoomValue = nameof(CameraZoomValue);
    private const string MusicVolume = nameof(MusicVolume);
    private const string SoundEffectsVolume = nameof(SoundEffectsVolume);

    private const string PlayerPosition = nameof(PlayerPosition);

    private const string PrefsHoldableObject = nameof(PrefsHoldableObject);

    private const string PrefsRecipeName = nameof(PrefsRecipeName);

    private const string PlayerPrefsOrderIsTaken = nameof(PlayerPrefsOrderIsTaken);

    private const string SavedInventoryList = nameof(SavedInventoryList);
    private const string SavedOrderedDishes = nameof(SavedOrderedDishes);
    private const string SavedPackedDishes = nameof(SavedPackedDishes);

    private const string SavedListFirstVillage = nameof(SavedListFirstVillage);
    private const string SavedListSecondVillage = nameof(SavedListSecondVillage);
    private const string SavedListThirdVillage = nameof(SavedListThirdVillage);
    private const string SavedListFourthVillage = nameof(SavedListFourthVillage);
    private const string SavedListLastVillage = nameof(SavedListLastVillage);

    private const string PlayerPrefsHasBackPack = nameof(PlayerPrefsHasBackPack);

    [SerializeField] private Player _player;
    [SerializeField] private Transform _defaultPlayerPosition;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private ObjectsSaver _objectSaver;

    [SerializeField] private Village _firstVillage;
    [SerializeField] private Village _secondVillage;
    [SerializeField] private Village _thirdVillage;
    [SerializeField] private Village _fourthVillage;
    [SerializeField] private Village _fifthVillage;

    private float _defaultCameraZoomValue = 30f;
    private float _defaultMusicVolume = 0.3f;
    private float _defaultSoundEffectsVolume = 0.5f;

    private SaveJson _saveJson;

    private void Awake()
    {
        _saveJson = new SaveJson();
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone += Save;

    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone -= Save;
    }

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetSavedData();
        }
    }

    public void ResetSavedData()
    {
        _player.transform.position = _defaultPlayerPosition.position;
        _saveJson.SavedInventoryListJson.Clear();
        _saveJson.SavedOrderedDishesListJson.Clear();
        _saveJson.SavedPackedDishesListJson.Clear();
    }

    // сохранение настроек камеры, музыки, звуковых эффектов. —охран€ютс€ при их изменении

    public float LoadCameraValue()
    {
        return PlayerPrefs.GetFloat(CameraZoomValue, _defaultCameraZoomValue);
    }

    public void SaveCameraValue(float cameraSliderValue)
    {
        PlayerPrefs.SetFloat(CameraZoomValue, cameraSliderValue);
    }

    public float LoadMusicVolume()
    {
        return PlayerPrefs.GetFloat(MusicVolume, _defaultMusicVolume);
    }

    public void SaveMusicVolume(float musicVolume)
    {
        PlayerPrefs.SetFloat(MusicVolume, musicVolume);
    }

    public float LoadSoundEffectVolume()
    {
        return PlayerPrefs.GetFloat(SoundEffectsVolume, _defaultSoundEffectsVolume);
    }

    public void SaveSoundEffectVolume(float soundEffectsVolume)
    {
        PlayerPrefs.SetFloat(SoundEffectsVolume, soundEffectsVolume);
    }

    // сохранение булки в ресивинг ордерз поинт

    private void SaveState(string nameOfState, int value)
    {
        PlayerPrefs.SetInt(nameOfState, value);
    }

    public bool LoadOrderIsTakenState()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsOrderIsTaken, 0));
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

    //—охранение листов 

    private void SaveLists(List<InventoryPrefabSO> inventoryToSave, List<CookingRecipeSO> orderedDishesToSave,
        List<CookingRecipeSO> packedDishesToSave)
    {
        _saveJson.SavedInventoryListJson = inventoryToSave;
        _saveJson.SavedOrderedDishesListJson = orderedDishesToSave;
        _saveJson.SavedPackedDishesListJson = packedDishesToSave;
        var outputString = JsonUtility.ToJson(_saveJson);
        var outputString2 = JsonUtility.ToJson(_saveJson);
        var outputString3 = JsonUtility.ToJson(_saveJson);
        PlayerPrefs.SetString(SavedInventoryList, outputString);
        PlayerPrefs.SetString(SavedOrderedDishes, outputString2);
        PlayerPrefs.SetString(SavedPackedDishes, outputString3);
    }

    private void SaveListsInAllVillages()
    {
        SaveListInVillage(_firstVillage.HousesWithDeliveredDish, _saveJson.SavedFirstVillageHouses, SavedListFirstVillage);
        SaveListInVillage(_secondVillage.HousesWithDeliveredDish, _saveJson.SavedSecondVillageHouses, SavedListSecondVillage);
        SaveListInVillage(_thirdVillage.HousesWithDeliveredDish, _saveJson.SavedThirdVillageHouses, SavedListThirdVillage);
        SaveListInVillage(_fourthVillage.HousesWithDeliveredDish, _saveJson.SavedFourthVillageHouses, SavedListFourthVillage);
        SaveListInVillage(_fifthVillage.HousesWithDeliveredDish, _saveJson.SavedFifthVillageHouses, SavedListLastVillage);
    }

    private void SaveListInVillage(List<House> housesToSave, List<House> saveJsonHousesToSave, string key)
    {
        saveJsonHousesToSave = housesToSave;
        var outputString = JsonUtility.ToJson(_saveJson);
        PlayerPrefs.SetString(key, outputString);
    }

    private List<House> Test()
    {
        string globalDataJSON = PlayerPrefs.GetString(SavedListFirstVillage);
        SaveJson loadedList = JsonUtility.FromJson<SaveJson>(globalDataJSON);

        foreach (var item in loadedList.SavedFirstVillageHouses)
        {
            print(item.name);
        }

        if (loadedList != null)
        {
            return loadedList.SavedFirstVillageHouses;
        }
        else
        {
            return new List<House>();
        }
    }

    private List<House> LoadHousesWithDeliveredDishes()
    {
        string dataJson = PlayerPrefs.GetString(SavedListFirstVillage);
        SaveJson loadedList = JsonUtility.FromJson<SaveJson>(dataJson);

        if (loadedList != null)
        {
            return loadedList.SavedFirstVillageHouses;
        }
        else
        {
            return new List<House>();
        }
    }

    // »нвентарь игрока

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

    // Ћисты в сервисе доставки

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

    //сохранение позиции игрока

    public Vector3 LoadPlayerPosition()
    {
        string globalDataJSON = PlayerPrefs.GetString(PlayerPosition);
        SaveJson loadedPlayerPosition = JsonUtility.FromJson<SaveJson>(globalDataJSON);

        if (loadedPlayerPosition != null)
        {
            return loadedPlayerPosition.SavedPlayerPositionToJson;
        }
        else
        {
            return _defaultPlayerPosition.position;
        }
    }

    private void SavePlayerPosition(Vector3 playerPositionToSave)
    {
        _saveJson.SavedPlayerPositionToJson = playerPositionToSave;
        string Json = JsonUtility.ToJson(_saveJson);
        PlayerPrefs.SetString(PlayerPosition, Json);
    }

    // сохранение обджект»н’эндс в плеер’эндс

    public HoldableObjectType LoadObjectInHands()
    {
        string json = PlayerPrefs.GetString(PrefsHoldableObject);
        SaveJson loadedObjectInHands = JsonUtility.FromJson<SaveJson>(json);

        if (loadedObjectInHands != null)
        {
            return loadedObjectInHands.SavedHoldableObject;
        }
        else
        {
            return 0;
        }
    }

    private void SaveObjectInHands(HoldableObjectType objectInHandsToSave)
    {
        _saveJson.SavedHoldableObject = objectInHandsToSave;
        string Json = JsonUtility.ToJson(_saveJson);
        PlayerPrefs.SetString(PrefsHoldableObject, Json);
    }

    // сохранение имени кукинг–есипи в ѕлеер укингћодуль

    private void SaveRecipeName(string recipeName)
    {
        PlayerPrefs.SetString(PrefsRecipeName, recipeName);
    }

    public string LoadRecipeName()
    {
        return PlayerPrefs.GetString(PrefsRecipeName);
    }

    // загрузка булки бэкпэк

    public bool LoadHasBackPack()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasBackPack));
    }

    private void Save()
    {
        SavePlayerPosition(_player.transform.position);
        SaveObjectInHands(_player.PlayerHands.HoldableObject);

        if (_player.PlayerCookingModule.CookingRecipeSO != null)
        {
            SaveRecipeName(_player.PlayerCookingModule.CookingRecipeSO.RecipeName);
        }

        SaveLists(_player.PlayerInventory.GetRecievedInventoryPrefabSOList(), _deliveryService.GetOrderedDishiesList(),
    _deliveryService.GetPackedDishiesList());

        SaveState(PlayerPrefsOrderIsTaken, ConvertBoolToInt(_recievingOrdersPoint.OrderIsTaken));

        SaveState(PlayerPrefsHasBackPack, ConvertBoolToInt(_player.PlayerHands.HasBackPack));

        SaveListsInAllVillages();

        _objectSaver.SaveContainers();
    }

    private void Load()
    {
        // _firstVillage.LoadHousesWithDeliveredDish(LoadHousesWithDeliveredDishes());

        List<House> temp = Test();

        foreach (var item in temp)
        {
            print(item.name);
        }

        _firstVillage.LoadHousesWithDeliveredDish(temp);
    }
}
