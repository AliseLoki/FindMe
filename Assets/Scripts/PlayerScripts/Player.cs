using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DeliveryService _deliveryService;
   
    [SerializeField] private Saver _saver;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
  
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

    private void Start()
    {
        if (!_gameStatesSwitcher.IsFirstStart)
        {
            transform.position = _saver.LoadPlayerPosition();
        }
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
        _playerHands.ShowOrHideBackPack(false);
    }
}
