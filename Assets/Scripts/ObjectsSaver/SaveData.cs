using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SaveData : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private DeliveryServiceView _deliveryServiceView;
    [SerializeField] private ObjectsSaver _objectsSaver;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
    [SerializeField] private SaveGameView _saveGameView;

    [SerializeField] private Transform _defaultPlayerPosition;

    // Подписываемся на событие GetDataEvent в OnEnable

    private bool _isInitialized = false;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
    }

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void Start()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();

            // Если запустился, то выполняем Ваш метод для загрузки
            // Если плагин еще не прогрузился, то метод не выполнится в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
            SceneManager.LoadScene(0);
        }
    }

    // Ваш метод для загрузки, который будет запускаться в старте
    private void GetLoad()
    {
        if (_isInitialized) return;

        _gameStatesSwitcher.SetFirstStart(YandexGame.savesData.IsFirstStart);

        if (YandexGame.savesData.IsFirstStart)
        {
            _player.transform.position = _defaultPlayerPosition.position;
        }
        else
        {
            _player.transform.position = YandexGame.savesData.PlayerPosition;
        }

        _player.PlayerHealth.GetHealth(YandexGame.savesData.Health);
        _player.PlayerGold.GetGold(YandexGame.savesData.Gold);
        _player.PlayerInventory.GetInventoryList(YandexGame.savesData.InventoryList);
        _player.PlayerHands.InitHasBackPack(YandexGame.savesData.HasBackPack);
        _player.PlayerHands.InitHoldableObjectType(YandexGame.savesData.HoldableObject);

        _recievingOrdersPoint.GetOrderIsTaken(YandexGame.savesData.OrderIsTaken);

        _deliveryService.GetLists(YandexGame.savesData.SavedOrderedDishesListJson, YandexGame.savesData.SavedPackedDishesListJson,
            YandexGame.savesData.SavedStatesOfReadyness);

        _deliveryServiceView.SetDestinationPointName(YandexGame.savesData.VillageName);

        _player.PlayerCookingModule.SetCookingRecipe(_player.PlayerCookingModule.FindRecipeByName(YandexGame.savesData.RecipeName));

        _objectsSaver.InitAllActiveContainers(YandexGame.savesData.ActiveContainers);
        _objectsSaver.InitAllActivePatches(YandexGame.savesData.ActivePatches);

        _objectsSaver.InitAllHouses(YandexGame.savesData.HouseIndexes);

        _objectsSaver.InitAllVillagesThatGaveReward(YandexGame.savesData.VillagesThatGaveReward);
        _objectsSaver.InitNotPickedRewards(YandexGame.savesData.VillagesWhereRewardIsntPicked);

        _isInitialized = true;
    }

    // Получаем данные из плагина и делаем с ними что хотим
    // Например, мы хотил записать в компонент UI.Text сколько у игрока монет:
    // textMoney.text = YandexGame.savesData.money.ToString();

    // Допустим, это Ваш метод для сохранения
    public void Save()
    {
        _saveGameView.ShowText();
        // Записываем данные в плагин
        // Например, мы хотил сохранить количество монет игрока:
        // YandexGame.savesData.money = money;
        YandexGame.savesData.Gold = _player.PlayerGold.Gold;
        YandexGame.savesData.Health = _player.PlayerHealth.Health;
        YandexGame.savesData.PlayerPosition = _player.transform.position;
        YandexGame.savesData.InventoryList = _player.PlayerInventory.RecievedInventoryPrefabSO;

        YandexGame.savesData.HasBackPack = _player.PlayerHands.HasBackPack;
        YandexGame.savesData.HoldableObject = _player.PlayerHands.HoldableObject;

        YandexGame.savesData.OrderIsTaken = _recievingOrdersPoint.OrderIsTaken;

        YandexGame.savesData.SavedOrderedDishesListJson = _deliveryService.OrderedDishies;
        YandexGame.savesData.SavedPackedDishesListJson = _deliveryService.PackedDishies;
        YandexGame.savesData.SavedStatesOfReadyness = _deliveryService.PackedDishesStates;

        if (_player.PlayerCookingModule.CookingRecipeSO != null)
        {
            YandexGame.savesData.RecipeName = _player.PlayerCookingModule.CookingRecipeSO.RecipeName;
        }

        YandexGame.savesData.ActiveContainers = _objectsSaver.SaveAllActiveContainers();
        YandexGame.savesData.ActivePatches = _objectsSaver.SaveAllActivePatches();

        YandexGame.savesData.HouseIndexes = _objectsSaver.SaveAllHousesThatRecivedOrders();

        YandexGame.savesData.VillageName = _deliveryServiceView.DestinationPointName;

        YandexGame.savesData.VillagesThatGaveReward = _objectsSaver.SaveRewardIsGiven();
        YandexGame.savesData.VillagesWhereRewardIsntPicked = _objectsSaver.SaveNotPickedRewards();
        YandexGame.savesData.IsFirstStart = _gameStatesSwitcher.IsFirstStart;
        // Теперь остаётся сохранить данные
        YandexGame.SaveProgress();
    }
}
