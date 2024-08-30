using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerEvents))]
[RequireComponent(typeof(PlayerCookingModule))]
[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _hasSomethingInHands;

    [SerializeField] private Transform _handlePoint;

    [SerializeField] private Transform _backpack;

    [SerializeField] private Transform _bucketOfWater;

    [SerializeField] private DeliveryService _deliveryService;

    [SerializeField] private TipsViewPanel _tipsViewPanel;

    [SerializeField] private LastVillage _lastVillage;

    [SerializeField] private AudioClip _takingWoodSoundEffect;

    [SerializeField] private AudioClip _getHurt;

    [SerializeField] private AudioClip _deathCry;

    [SerializeField] private ParticleSystem _hitEffect;


    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private Spawner _spawner;

    private bool _hasBackPack;
    private bool _hasWood;
    private bool _hasSeed;
    private bool _hasWater;
    private bool _hasSword;
    private bool _hasNecronomicon;

    private bool _hasCow;
    private bool _hasCabbageForSeeds;
    private bool _hasTomatoForSeeds;

    private InventoryPrefabSO _inventoryPrefabSO;
    private PlayerEvents _playerEvents;
    private PlayerCookingModule _playerCookingModule;
    private PlayerInventory _playerInventory;
    private PlayerMovement _playerMovement;
    private AudioSource _audioSource;

    public bool HasSomethingInHands => _hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasWood => _hasWood;

    public bool HasSeed => _hasSeed;

    public bool HasWater => _hasWater;

    public bool HasSword => _hasSword;

    public bool HasNecronomicon => _hasNecronomicon;


    public bool HasCow => _hasCow;
    public bool HasTomatoForSeeds => _hasTomatoForSeeds;
    public bool HasCabbageForSeeds => _hasCabbageForSeeds;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerEvents PlayerEventsHandler => _playerEvents;

    public PlayerCookingModule PlayerCookingModule => _playerCookingModule;

    public PlayerInventory PlayerInventory => _playerInventory;

    public Transform HandlePoint => _handlePoint;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerEvents = GetComponent<PlayerEvents>();
        _playerCookingModule = GetComponent<PlayerCookingModule>();
        _playerInventory = GetComponent<PlayerInventory>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        _hasWood = _saveSystem.LoadHasWood();
        _hasBackPack = _saveSystem.LoadHasBackPack();
        _hasWater = _saveSystem.LoadHasWater();
        _hasSword = _saveSystem.LoadHasSword();
        _hasSeed = _saveSystem.LoadHasSeed();
        _hasCow = _saveSystem.LoadHasCow();
        _hasTomatoForSeeds = _saveSystem.LoadHasTomatoForSeeds();
        _hasCabbageForSeeds = _saveSystem.LoadHasCabbageForSeeds();
        Load();
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

    public void PlayDeathSound()
    {
        PlaySoundEffect(_deathCry);
    }

    public void PlayHitEffects()
    {
        PlaySoundEffect(_getHurt);
        _hitEffect.Play();
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public void SetHasWood(bool hasWood)
    {
        _hasWood = hasWood;

        if (_hasWood == true)
        {
            PlaySoundEffect(_takingWoodSoundEffect);
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
        _hasBackPack = isActive;
    }

    public void SetHasSomethingInHands(bool hasSomethingInhands)
    {
        _hasSomethingInHands = hasSomethingInhands;
    }

    public void TakeSeedInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _hasSeed = true;
        _tipsViewPanel.ShowBringmeToPatchTip();
    }

    public void TakeSwordInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _hasSword = true;
        _tipsViewPanel.ShowYouCankillTheWolfNowTip();
    }

    public void TakeNecronomiconInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _hasNecronomicon = true;
    }

    public void LandSeed()
    {
        CheckWitchSeed(_inventoryPrefabSO, false);
        Destroy(_handlePoint.GetChild(0).gameObject);
        _hasSeed = false;
        SetHasSomethingInHands(false);
        _inventoryPrefabSO = null;
    }

    public InventoryPrefabSO SetInventoryPrefabSO()
    {
        return _inventoryPrefabSO;
    }

    public void TakeWater()
    {
        _hasWater = true;
        _hasSomethingInHands = true;
        var waterInHands = Instantiate(_bucketOfWater, HandlePoint, true);
        waterInHands.transform.position = HandlePoint.position;
    }

    public void GiveWater()
    {
        _hasWater = false;
        _hasSomethingInHands = false;
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    private void Load()
    {
        if (_hasBackPack == true)
        {
            ShowOrHideBackPack(true);
        }

        if (_hasWood == true)
        {
            _spawner.SpawnWoodInHands();
        }
        else if (_hasWater == true)
        {
            TakeWater();
        }
        else if (_hasSword == true)
        {
            _inventoryPrefabSO = _spawner.SpawnSwordInHands();
        }
        else if (_hasCow == true)
        {
            _inventoryPrefabSO = _spawner.SpawnCowInHands();
        }
        else if (_hasTomatoForSeeds == true)
        {
            _inventoryPrefabSO = _spawner.SpawnTomatoForSeedsInHands();
        }
        else if (_hasCabbageForSeeds == true)
        {
            _inventoryPrefabSO = _spawner.SpawnCabbageForSeedsInHands();
        }
    }

    private void OnWolfHasBeenKilled()
    {
        _hasSword = false;
        _hasSomethingInHands = false;
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
            _hasCow = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as CabbageForSeeds)
        {
            _hasCabbageForSeeds = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
        {
            _hasTomatoForSeeds = isTrue;
        }
    }
}
