using UnityEngine;
using Agava.YandexGames;
using System.Collections.Generic;

public class Saver : MonoBehaviour
{
    private const string CameraZoomValue = nameof(CameraZoomValue);
    private const string MusicVolume = nameof(MusicVolume);
    private const string SoundEffectsVolume = nameof(SoundEffectsVolume);

    private const string PlayerPosition = nameof(PlayerPosition);

    private const string PlayerPrefsOrderIsTaken = nameof(PlayerPrefsOrderIsTaken);

    private const string SavedInventoryList = nameof(SavedInventoryList);
    private const string SavedOrderedDishes = nameof(SavedOrderedDishes);
    private const string SavedPackedDishes = nameof(SavedPackedDishes);

    [SerializeField] private Player _player;
    [SerializeField] private Transform _defaultPlayerPosition;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;

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
    //

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



    private void Save()
    {
        SavePlayerPosition(_player.transform.position);
        SaveLists(_player.PlayerInventory.GetRecievedInventoryPrefabSOList(), _deliveryService.GetOrderedDishiesList(),
    _deliveryService.GetPackedDishiesList());
        SaveState(PlayerPrefsOrderIsTaken, ConvertBoolToInt(_recievingOrdersPoint.OrderIsTaken));
    }

    //загружаем настройки камеры
    //загружаем настройки музыки
    //загружаем настройки саунд эффектов

    //загружаем позицию игрока

    //

    // что делать с ферст стартом

    // вызываем метод инит в плеере


}
