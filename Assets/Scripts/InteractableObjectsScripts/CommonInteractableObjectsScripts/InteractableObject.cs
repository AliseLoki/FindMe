using DeliveryServiceHandler;
using Indexies;
using PlayerController;
using UnityEngine;

namespace Interactables
{
    public abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField] private SelectedObject SelectedObject;
        [SerializeField] private AudioClip _clip;
        [SerializeField] protected PlayerOld Player;
        [SerializeField] protected PlayerInventory PlayerInventory;
        [SerializeField] protected DeliveryService DeliveryService;
        [SerializeField] protected DeliveryServiceView DeliveryServiceView;
        [SerializeField] protected ActivableObjectType _activableObjectType;
        [SerializeField] protected HoldableObjectType _holdableObjects;

        public AudioClip Clip => _clip;

        public ActivableObjectType ActivableObject => _activableObjectType;

        public HoldableObjectType HoldableObjects => _holdableObjects;

        public void InitLinks(PlayerOld player, PlayerInventory playerInventory)
        {
            Player = player;
            PlayerInventory = playerInventory;
        }

        public void EnableInteract()
        {
            SelectedObject.Show();
        }

        public void DisableInteract()
        {
            SelectedObject.Hide();
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