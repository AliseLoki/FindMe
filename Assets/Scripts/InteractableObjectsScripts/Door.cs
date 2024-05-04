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
        _canvasUI.FadeToBlack();
        _cameras.SwitchCameras();
        Player.transform.position = _newPosition.position;
    }
}
