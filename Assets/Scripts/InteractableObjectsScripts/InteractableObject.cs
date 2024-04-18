using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected SelectedObject _selectedObject;
    
    private bool _isSelected;

    protected Player Player1;

    private void Awake()
    {
        Player1 = GameManager.Instance.InitPlayer();
    }

    public void EnableInteract()
    {
        _selectedObject.Show();
        _isSelected = true;

        if (this as CookingTable)
        {
            TipsViewPanel.Instance.ShowThisIsCookingTableTip();
        }
        else if(this as RussianOven)
        {
            TipsViewPanel.Instance.ShowThisISOvenTip();
        }
        else if (this as CuttingTable)
        {
           TipsViewPanel.Instance.ShowThisIsCuttingTableTip();
        }
        else if(this as PackingPlace)
        {
            TipsViewPanel.Instance.ShowThisIsPackingPlaceTip();
        }
        else if (this as GarbageContainer)
        {
            TipsViewPanel.Instance.ShowThisIsGarbageTip();
        }
        else
        {
            TipsViewPanel.Instance.ShowTapTheObjectTip();
        }
    }

    public void DisableInteract()
    {
        _selectedObject.Hide();
        _isSelected = false;
        TipsViewPanel.Instance.EraseTip();
    }

    protected abstract void UseObject();

    protected void InitializePlayer()
    {
        
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
}
