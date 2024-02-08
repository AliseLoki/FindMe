using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private SelectedObject _selectedObject;

    private bool _isSelected;
    private SelectedObject _defaultSelectedObject;

    public void Interact()
    {
        if (_selectedObject != _defaultSelectedObject)
        {
            _selectedObject.Show();
            _defaultSelectedObject = _selectedObject;
            _isSelected = true;
        }
        else
        {
            _selectedObject.Hide();
            _defaultSelectedObject = null;
            _isSelected = false;
        }
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
