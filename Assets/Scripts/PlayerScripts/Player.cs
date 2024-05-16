using UnityEngine;

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

    [SerializeField] private AudioClip _takingWoodSoundEffect;

    private bool _hasBackPack;
    private bool _hasWood;
    private bool _hasSeed;
    private bool _hasWater;

    private InventoryPrefabSO _inventoryPrefabSO;

    private PlayerEvents _playerEvents;
    private PlayerCookingModule _playerCookingModule;
    private PlayerInventory _playerInventory;
    private AudioSource _audioSource;

    public bool HasSomethingInHands => _hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasWood => _hasWood;

    public bool HasSeed => _hasSeed;

    public bool HasWater => _hasWater;

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
    }

    private void OnEnable()
    {
        _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }
    private void OnDisable()
    {
        _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public void SetHasWood(bool hasWood)
    {
        _hasWood = hasWood;

        if(_hasWood == true)
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
        var seedInHands = Instantiate(inventoryPrefabSO.InventoryPrefab, HandlePoint, true);
        seedInHands.transform.position = HandlePoint.position;
        _hasSeed = true;
        SetHasSomethingInHands(true);
        _inventoryPrefabSO = inventoryPrefabSO;
    }

    public void LandSeed()
    {
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

    private void OnAllDishesHaveBeenDelivered()
    {
        ShowOrHideBackPack(false);
    }
}
