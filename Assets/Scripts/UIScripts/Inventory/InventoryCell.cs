using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _inventoryCellImage;

    private InventoryPrefabSO _inventoryPrefabSO;
    private Player _player;
    private TipsViewPanel _tipsViewPanel;

    public event Action<InventoryPrefabSO> InventoryCellButtonPressed;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    public void SetInventoryCellImage(InventoryPrefabSO inventoryPrefabSO)
    {
        _inventoryCellImage.sprite = inventoryPrefabSO.Sprite;
        _inventoryPrefabSO = inventoryPrefabSO;
    }

    public void OnInventoryCellButtonPressed()
    {
        if (!_player.HasSomethingInHands)
        {
            if (_inventoryPrefabSO.InventoryPrefab as Necronomicon)
            {
                if (!GameManager.Instance.IsWitchAppeared())
                {
                    _tipsViewPanel.ShowItIsNotRightTimeTip();
                }
                else
                {
                    InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
                    Destroy(this.gameObject, 0.5f);
                }
            }
            else
            {
                InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
                Destroy(this.gameObject, 0.5f);
            }
        }
        else
        {
            _tipsViewPanel.ShowHandsAreFullTip();
        }
    }

    private void RemoveInventoryCell()
    {
        InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
        Destroy(this.gameObject, 0.5f);
    }
}
