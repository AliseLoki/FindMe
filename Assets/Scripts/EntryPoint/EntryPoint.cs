using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private DeliveryServiceView _deliveryServiceView;
    [SerializeField] private CookingTable _cookingTable;
    [SerializeField] private PackingPlace _packingPlace;
    [SerializeField] private LanguageSwitcher _languageSwitcher;
     
    public Player InitPlayer()
    {
        return _player;
    }

    public TipsViewPanel InitTipsViewPanel()
    {
        return _tipsViewPanel;
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

    public CookingTable InitCookingTable()
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

    public LanguageSwitcher InitLanguageSwitcher()
    {
        return _languageSwitcher;
    }
}
