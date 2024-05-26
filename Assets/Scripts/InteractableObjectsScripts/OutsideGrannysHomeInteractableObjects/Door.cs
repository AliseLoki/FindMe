using UnityEngine;

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
        int openingDoorSoundEffectIndex = 0;
        PlaySoundEffect(AudioClipsList[openingDoorSoundEffectIndex]);
        _canvasUI.FadeToBlack();
        _cameras.SwitchCameras();
        Player.PlayerMovement.Teleport(_newPosition);
    }
}
