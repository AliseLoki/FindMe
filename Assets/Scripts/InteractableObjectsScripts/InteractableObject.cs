using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected SelectedObject _selectedObject;

    private bool _isSelected;
  
    public void EnableInteract()
    {
        _selectedObject.Show();
        _isSelected = true;
        TipsViewPanel.Instance.ShowTapTheObjectTip();
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
            TipsViewPanel.Instance.ShowApproachTip();
        }
    }

    protected abstract void UseObject();
}
