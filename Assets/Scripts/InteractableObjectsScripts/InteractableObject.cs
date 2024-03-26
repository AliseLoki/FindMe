using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected SelectedObject _selectedObject;

    private bool _isSelected;
  
    public void EnableInteract()
    {
        _selectedObject.Show();
        _isSelected = true;
    }

    public void DisableInteract()
    {
        _selectedObject.Hide();
        _isSelected = false;
    }

    private void OnMouseDown()
    {
        if (_isSelected)
        {
            UseObject();
        }
        else if (!_isSelected)
        {
            print("сначала подойдите к объекту");
        }
    }

    protected abstract void UseObject();
}
