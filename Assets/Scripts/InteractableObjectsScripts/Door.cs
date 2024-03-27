using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private Transform _newPosition;
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private Cameras _cameras;
   
    
    private void OnEnable()
    {
        _selectedObject.Hide();
    }

    protected override void UseObject()
    {
        _canvasUI.FadeToBlack();
        _cameras.SwitchCameras();
        Player.Instance.transform.position = _newPosition.position;
    }
}
