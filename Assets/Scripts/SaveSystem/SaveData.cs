using DeliveryServiceHandler;
using GameControllers;
using Interactables;
using MainCanvas;
using PlayerController;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace SaveSystem
{
    public class SaveData : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
        [SerializeField] private DeliveryService _deliveryService;
        [SerializeField] private DeliveryServiceView _deliveryServiceView;
        [SerializeField] private ObjectsSaver _objectsSaver;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private Transform _defaultPlayerPosition;
        [SerializeField] private CanvasUI _canvasUI;

        private bool _isInitialized = false;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += GetLoad;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= GetLoad;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                GetLoad();
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

        private void GetLoad()
        {
            if (_isInitialized) return;

            _gameStatesSwitcher.SetFirstStart(YandexGame.savesData.IsFirstStart);
            _canvasUI.LanguageSetter.SetCurrentLanguage(YandexGame.EnvironmentData.language);

            if (YandexGame.savesData.IsFirstStart)
            {
                _player.transform.position = _defaultPlayerPosition.position;
            }
            else
            {
                _player.transform.position = YandexGame.savesData.PlayerPosition;
            }

            _player.PlayerHealth.InitHealth(YandexGame.savesData.Health);
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

        public void Save()
        {

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
            YandexGame.SaveProgress();
            _canvasUI.ShowSavedScreen();
        }
    }
}