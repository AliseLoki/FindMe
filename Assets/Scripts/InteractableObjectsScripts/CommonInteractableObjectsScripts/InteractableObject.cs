using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected SelectedObject SelectedObject;
    [SerializeField] protected List<AudioClip> AudioClipsList;

    protected AudioSource AudioSource;
    protected Player Player;
    protected PlayerInventory PlayerInventory;
    protected TipsViewPanel TipsViewPanel;
    protected DeliveryService DeliveryService;
    protected DeliveryServiceView DeliveryServiceView;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        Player = GameManager.Instance.GameEntryPoint.InitPlayer();
        PlayerInventory = GameManager.Instance.GameEntryPoint.InitPlayerInventory();
        TipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
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

    protected virtual void PlaySoundEffect(AudioClip audioClip)
    {
        AudioSource.PlayOneShot(audioClip);
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
        if (this as CookingTable)
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
        else if (this as RecievingOrdersPoint)
        {
            TipsViewPanel.ShowThisIsRecievingOrdersPointTip();
        }
        else if (this as Wood)
        {
            TipsViewPanel.ShowPutWoodInOvenTip();
        }
        else if (this as House)
        {
            TipsViewPanel.ShowThisIsHouseTip();
        }
        else if (this as Mushroom)
        {
            TipsViewPanel.ShowEatMeTip();
        }
        else if (this as Necronomicon)
        {
            TipsViewPanel.ShowKillTheWitchTip();
        }
        else if (this as Sword)
        {
            TipsViewPanel.ShowKillTheWolfTip();
        }
        else if (this as Well)
        {
            TipsViewPanel.ShowPutGoldInMeTip();
        }
        else if (this as CowPlace)
        {
            TipsViewPanel.ShowYouCanBringACowHereTip();
        }
        else if (this as Patch)
        {
            TipsViewPanel.ShowHereYouCanGrowVegetablesTip();
        }
        else if (this as CabbageForSeeds || this as TomatoForSeeds)
        {
            TipsViewPanel.ShowTakeMeTip();
        }
        else
        {
            TipsViewPanel.ShowTapTheObjectTip();
        }
    }
}
