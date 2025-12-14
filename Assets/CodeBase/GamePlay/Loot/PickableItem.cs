using Assets.CodeBase.Infrastructure.Services.Interactions;
using UnityEngine;

namespace Assets.CodeBase.GamePlay.Loot
{
    public class PickableItem : Interactable
    {
        [SerializeField] private PickableType _pickableType;
       
        private PickableInteractionService _interactionService;

        public void Init(PickableInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        protected override void UseObject()
        {
           _interactionService.Pick(_pickableType, _clip);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            EnableInteract();
        }

        private void OnTriggerExit(Collider other)
        {
            DisableInteract();
        }
    }
}
