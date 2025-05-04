using MainCanvas;
using UnityEngine;

namespace Interactables
{
    public class Door : InteractableObject
    {
        [SerializeField] private Transform _newPosition;
        [SerializeField] private CanvasUI _canvasUI;
        [SerializeField] private Cameras _cameras;

        private void OnEnable()
        {
            DisableInteract();
        }

        protected override void UseObject()
        {
            TeleportPlayer();
        }

        private void TeleportPlayer()
        {
            Player.PlayerSoundEffects.PlaySoundEffect(Clip);
            _canvasUI.FadeToBlack();
            _cameras.SwitchCameras();
            Player.PlayerMovement.Teleport(_newPosition);
        }
    }
}