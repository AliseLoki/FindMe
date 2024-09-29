using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _handlePoint;
    [SerializeField] private Transform _backpack;
    [SerializeField] private Transform _bucketOfWater;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private LastVillage _lastVillage;

    [SerializeField] private Saver _saver;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private InventoryPrefabSO _inventoryPrefabSO;

    [SerializeField] private PlayerEvents _playerEvents;
    [SerializeField] private PlayerCookingModule _playerCookingModule;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHands _playerHands;
    [SerializeField] private PlayerSoundEffects _playerSoundEffects;
    [SerializeField] private PlayerAnimation _playerAnimation;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerEvents PlayerEventsHandler => _playerEvents;

    public PlayerCookingModule PlayerCookingModule => _playerCookingModule;

    public PlayerInventory PlayerInventory => _playerInventory;

    public PlayerHands PlayerHands => _playerHands;

    public PlayerSoundEffects PlayerSoundEffects => _playerSoundEffects;

    public PlayerAnimation PlayerAnimation => _playerAnimation;

    public Transform HandlePoint => _handlePoint;


    private void Start()
    {
        if (!_gameStatesSwitcher.IsFirstStart)
        {
            transform.position = _saver.LoadPlayerPosition();
        }
        //  InitAllBooleans();
        //Load();
    }

    private void OnEnable()
    {
        _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
        _playerEvents.WolfHasBeenKilled += OnWolfHasBeenKilled;
        _lastVillage.WitchAppeared += OnWitchAppeared;
    }

    private void OnDisable()
    {
        _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
        _playerEvents.WolfHasBeenKilled -= OnWolfHasBeenKilled;
        _lastVillage.WitchAppeared -= OnWitchAppeared;
    }

    //непонятно это просто сокращенная запись метода, без кудрявых скобок?
    //public void InitState(PlayerStatesToSave playerState) => StatesToSave = playerState;

    //public void InitAllBooleans()
    //{
    //    _hasWood = _saveSystem.LoadHasWood();
    //    _hasBackPack = _saveSystem.LoadHasBackPack();
    //    _hasWater = _saveSystem.LoadHasWater();
    //    _hasSword = _saveSystem.LoadHasSword();
    //    _hasSeed = _saveSystem.LoadHasSeed();
    //    _hasCow = _saveSystem.LoadHasCow();
    //    _hasTomatoForSeeds = _saveSystem.LoadHasTomatoForSeeds();
    //    _hasCabbageForSeeds = _saveSystem.LoadHasCabbageForSeeds();
    //}


    public void SetHasWood(bool hasWood)
    {
        _playerHands.HasWood = hasWood;

        if (_playerHands.HasWood == true)
        {
            _playerSoundEffects.PlayTakingWoodSoundEffect();
        }
    }

    public void ResetWoodPrefab()
    {
        SetHasWood(false);
        SetHasSomethingInHands(false);
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    public void ShowOrHideBackPack(bool isActive)
    {
        _backpack.gameObject.SetActive(isActive);
        _playerHands.HasBackPack = isActive;
    }

    public void SetHasSomethingInHands(bool hasSomethingInhands)
    {
        _playerHands.HasSomethingInHands = hasSomethingInhands;
    }

    public void TakeSeedInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _playerHands.HasSeed = true;
        _tipsViewPanel.ShowBringmeToPatchTip();
    }

    public void TakeSwordInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _playerHands.HasSword = true;
        _tipsViewPanel.ShowYouCankillTheWolfNowTip();
    }

    public void TakeNecronomiconInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _playerHands.HasNecronomicon = true;
    }

    public void LandSeed()
    {
        CheckWitchSeed(_inventoryPrefabSO, false);
        Destroy(_handlePoint.GetChild(0).gameObject);
        _playerHands.HasSeed = false;
        SetHasSomethingInHands(false);
        _inventoryPrefabSO = null;
    }

    public InventoryPrefabSO SetInventoryPrefabSO()
    {
        return _inventoryPrefabSO;
    }

    public void TakeWater()
    {
        _playerHands.HasWater = true;
        _playerHands.HasSomethingInHands = true;
        var waterInHands = Instantiate(_bucketOfWater, HandlePoint, true);
        waterInHands.transform.position = HandlePoint.position;
    }

    public void GiveWater()
    {
        _playerHands.HasWater = false;
        _playerHands.HasSomethingInHands = false;
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    //private void Load()
    //{
    //    if (_hasBackPack == true)
    //    {
    //        ShowOrHideBackPack(true);
    //    }

    //    if (_hasWood == true)
    //    {
    //        _spawner.SpawnWoodInHands();
    //    }
    //    else if (_hasWater == true)
    //    {
    //        TakeWater();
    //    }
    //    else if (_hasSword == true)
    //    {
    //        _inventoryPrefabSO = _spawner.SpawnSwordInHands();
    //    }
    //    else if (_hasCow == true)
    //    {
    //        _inventoryPrefabSO = _spawner.SpawnCowInHands();
    //    }
    //    else if (_hasTomatoForSeeds == true)
    //    {
    //        _inventoryPrefabSO = _spawner.SpawnTomatoForSeedsInHands();
    //    }
    //    else if (_hasCabbageForSeeds == true)
    //    {
    //        _inventoryPrefabSO = _spawner.SpawnCabbageForSeedsInHands();
    //    }
    //}

    private void OnWolfHasBeenKilled()
    {
        _playerHands.HasSword = false;
        _playerHands.HasSomethingInHands = false;
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    private void OnWitchAppeared(Witch witch)
    {
        _playerMovement.LookAtTheWitch(witch);
    }

    private void TakeInvenoryPrefabInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        CheckWitchSeed(inventoryPrefabSO, true);
        var prefabInHands = Instantiate(inventoryPrefabSO.InventoryPrefab, HandlePoint, true);
        prefabInHands.transform.position = HandlePoint.position;
        prefabInHands.GetComponent<Collider>().enabled = false;

        if (!CheckIfCow(inventoryPrefabSO))
        {
            prefabInHands.transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        else
        {
            prefabInHands.transform.rotation = Quaternion.LookRotation(transform.right);
        }

        SetHasSomethingInHands(true);
        _inventoryPrefabSO = inventoryPrefabSO;
    }

    private bool CheckIfCow(InventoryPrefabSO inventoryPrefabSO)
    {
        if ((inventoryPrefabSO.InventoryPrefab as Cow))
        {
            return true;
        }

        return false;
    }

    private void OnAllDishesHaveBeenDelivered()
    {
        ShowOrHideBackPack(false);
    }

    private void CheckWitchSeed(InventoryPrefabSO inventoryPrefabSO, bool isTrue)
    {
        if (inventoryPrefabSO.InventoryPrefab as Cow)
        {
            _playerHands.HasCow = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as CabbageForSeeds)
        {
            _playerHands.HasCabbageForSeeds = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
        {
            _playerHands.HasTomatoForSeeds = isTrue;
        }
    }
}
