using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected SelectedObject SelectedObject;

    protected SoundEffects SoundEffects;
    protected Player Player;
    protected TipsViewPanel TipsViewPanel;
    protected DeliveryService DeliveryService;
    protected DeliveryServiceView DeliveryServiceView;
    
    private void Awake()
    {
        Player = GameManager.Instance.GameEntryPoint.InitPlayer();
        TipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
        SoundEffects = GameManager.Instance.GameEntryPoint.InitSoundEffects();
        DeliveryService = GameManager.Instance.GameEntryPoint.InitDeliveryService();
        DeliveryServiceView = GameManager.Instance.GameEntryPoint.InitDeliveryServiceView();
    }

    public void EnableInteract()
    {
        SelectedObject.Show();
        ShowTips();
    }

    public void DisableInteract()
    {
        SelectedObject.Hide();
        TipsViewPanel.EraseTip();
    }

    protected abstract void UseObject();

    private void OnMouseDown()
    {
        if (SelectedObject.isActiveAndEnabled)
        {
            UseObject();
        }
        else
        {
            TipsViewPanel.ShowApproachTip();
        }
    }

    private void ShowTips()
    {
        if (this as TestingTable)
        {
            TipsViewPanel.ShowThisIsCookingTableTip();
        }
        else if (this as RussianOven)
        {
            TipsViewPanel.ShowThisISOvenTip();
        }
        else if (this as CuttingTable)
        {
            TipsViewPanel.ShowThisIsCuttingTableTip();
        }
        else if (this as PackingPlace)
        {
            TipsViewPanel.ShowThisIsPackingPlaceTip();
        }
        else if (this as GarbageContainer)
        {
            TipsViewPanel.ShowThisIsGarbageTip();
        }
        else if (this as Container)
        {
            TipsViewPanel.ShowThisIsContainerTip();
        }
        else if(this as RecievingOrdersPoint)
        {
            TipsViewPanel.ShowThisIsRecievingOrdersPointTip();
        }
        else if(this as Wood)
        {
            TipsViewPanel.ShowPutWoodInOvenTip();
        }
        else  if(this as House)
        {
            TipsViewPanel.ShowThisIsHouseTip();
        }
        else if(this as Mushroom)
        {
            TipsViewPanel.ShowEatMeTip();
        }
        else if(this as Necronomicon)
        {
            TipsViewPanel.ShowTakeMeTip();
        }
        else
        {
            TipsViewPanel.ShowTapTheObjectTip();
        }
    }
}
