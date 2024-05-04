using UnityEngine;

[RequireComponent(typeof(PlayerEvents))]
[RequireComponent(typeof(PlayerCookingModule))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool _hasSomethingInHands;

    [SerializeField] private Transform _handlePoint;

    [SerializeField] private Transform _backpack;

    [SerializeField] private DeliveryService _deliveryService;

    private bool _hasBackPack;
    private bool _hasWood;

    private PlayerEvents _playerEvents;
    private PlayerCookingModule _playerCookingModule;
   
    public bool HasSomethingInHands => _hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasWood => _hasWood;

    public PlayerEvents PlayerEventsHandler => _playerEvents;

    public PlayerCookingModule PlayerCookingModule => _playerCookingModule;

    public Transform HandlePoint => _handlePoint;

    private void Awake()
    {
        _playerEvents = GetComponent<PlayerEvents>();
        _playerCookingModule = GetComponent<PlayerCookingModule>();
    }

    private void OnEnable()
    {
        _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }
    private void OnDisable()
    {
        _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
    }
   
    private void OnAllDishesHaveBeenDelivered()
    {
        ShowOrHideBackPack(false);
    }

    public void SetHasWood(bool hasWood)
    {
        _hasWood = hasWood;
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
}
