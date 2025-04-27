using DeliveryServiceHandler;
using Indexies;
using PlayerController;
using UIPanels;
using UnityEngine;

namespace Interactables
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected SelectedObject SelectedObject;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private Tips _tip;

        public AudioClip Clip =>_clip;

         [SerializeField] protected TipsViewPanel _tipsViewPanel;

        [SerializeField] protected Player Player;
        [SerializeField] protected PlayerInventory PlayerInventory;
        [SerializeField] protected DeliveryService DeliveryService;
        [SerializeField] protected DeliveryServiceView DeliveryServiceView;
        [SerializeField] protected ActivableObjectType _activableObjectType;
        [SerializeField] protected HoldableObjectType _holdableObjects;

        public ActivableObjectType ActivableObject => _activableObjectType;

        public HoldableObjectType HoldableObjects => _holdableObjects;

        public void InitLinks(TipsViewPanel tipsViewPanel, Player player, PlayerInventory playerInventory)
        {
            _tipsViewPanel = tipsViewPanel;
            Player = player;
            PlayerInventory = playerInventory;
        }

        public void EnableInteract()
        {
            SelectedObject.Show();
            _tipsViewPanel.ShowTip(_tip);
        }

        public void DisableInteract()
        {
            SelectedObject.Hide();
            _tipsViewPanel.EraseTip();
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

        protected abstract void UseObject();

        private void OnMouseDown()
        {
            if (SelectedObject.isActiveAndEnabled)
            {
                UseObject();
            }
        }
    }
}
