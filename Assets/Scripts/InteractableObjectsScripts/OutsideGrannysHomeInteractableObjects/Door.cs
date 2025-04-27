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
            SelectedObject.Hide();
        }

        protected override void UseObject()
        {
            TeleportPlayer();
        }

        private void TeleportPlayer()
        {
            int openingDoorSoundEffectIndex = 0;
           // PlaySoundEffect(AudioClipsList[openingDoorSoundEffectIndex]);//
            _canvasUI.FadeToBlack();
            _cameras.SwitchCameras();
            Player.PlayerMovement.Teleport(_newPosition);
        }
    }
}
