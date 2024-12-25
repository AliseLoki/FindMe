using System.Collections.Generic;
using UnityEngine;
using DeliveryServiceHandler;
using Interactables.Containers;
using Interactables.InventoryPrefabs;
using Interactables.Containers.Tables;
using Interactables.Patches;
using Interactables.InventoryPrefabs.Mushrooms;
using PlayerController;
using Indexes;

namespace Interactables
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected SelectedObject SelectedObject;
        [SerializeField] protected List<AudioClip> AudioClipsList;
        [SerializeField] protected Player Player;
        [SerializeField] protected PlayerInventory PlayerInventory;
        [SerializeField] protected TipsViewPanel TipsViewPanel;
        [SerializeField] protected DeliveryService DeliveryService;
        [SerializeField] protected DeliveryServiceView DeliveryServiceView;

        [SerializeField] protected ActivableObjectType _activableObjectType;
        [SerializeField] protected HoldableObjectType _holdableObjects;

        protected AudioSource AudioSource;

        public ActivableObjectType ActivableObject => _activableObjectType;

        public HoldableObjectType HoldableObjects => _holdableObjects;

        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
        }

        public void InitLinks(TipsViewPanel tipsViewPanel, Player player, PlayerInventory playerInventory)
        {
            TipsViewPanel = tipsViewPanel;
            Player = player;
            PlayerInventory = playerInventory;
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

        public void DisableCollider()
        {
            if (TryGetComponent(out Collider collider))
            {
                collider.enabled = false;
            }

            if (SelectedObject != null)
            {
                SelectedObject.Hide();
            }
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
}
