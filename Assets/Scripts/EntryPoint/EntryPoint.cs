using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private DeliveryServiceView _deliveryServiceView;
    [SerializeField] private TestingTable _cookingTable;
    [SerializeField] private PackingPlace _packingPlace;
     
    public Player InitPlayer()
    {
        return _player;
    }

    public TipsViewPanel InitTipsViewPanel()
    {
        return _tipsViewPanel;
    }

    public SoundEffects InitSoundEffects()
    {
        return _soundEffects;
    }

    public RecievingOrdersPoint InitRecievingOrdersPoint()
    {
        return _recievingOrdersPoint;
    }

    public DeliveryService InitDeliveryService()
    {
        return _deliveryService;
    }

    public DeliveryServiceView InitDeliveryServiceView()
    {
        return _deliveryServiceView;
    }

    public TestingTable InitCookingTable()
    {
        return _cookingTable;
    }

    public PackingPlace InitPackingPlace()
    {
        return _packingPlace;
    }

    public PlayerInventory InitPlayerInventory()
    {
        return _playerInventory;
    }
}
