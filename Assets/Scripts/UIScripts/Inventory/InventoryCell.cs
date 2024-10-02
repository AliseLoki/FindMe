using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _inventoryCellImage;

    private InventoryPrefabSO _inventoryPrefabSO;
    private HoldableObjects _holdableIndex;

    [SerializeField] private Player _player;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;


    public event Action<InventoryPrefabSO> InventoryCellButtonPressed;

    private void OnEnable()
    {
        //SetInventoryCellImage(_inventoryPrefabSO);
    }

    public void InitLinks(Player player,GameStatesSwitcher gameStatesSwitcher,TipsViewPanel tipsViewPanel)
    {
        _player = player;
        _gameStatesSwitcher = gameStatesSwitcher;
        _tipsViewPanel = tipsViewPanel;
    }

    public void SetInventoryCellImage(InventoryPrefabSO inventoryPrefabSO)
    {
        _inventoryCellImage.sprite = inventoryPrefabSO.Sprite;
        _inventoryPrefabSO = inventoryPrefabSO;
        //передаем индекс префаба, привязанного к инвенториПрефабу в инвенториПрефабСО
        //_holdableIndex = inventoryPrefabSO.InventoryPrefab.HoldableObjects;
    }

    public void OnInventoryCellButtonPressed()
    {
        if (!_player.PlayerHands.HasSomethingInHands)
        {
            if (_inventoryPrefabSO.InventoryPrefab as Necronomicon)
            {
                if (!_gameStatesSwitcher.IsWitchAppeared())
                {
                    _tipsViewPanel.ShowItIsNotRightTimeTip();
                }
                else
                {
                    RemoveInventoryCell();
                   // InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
                   // Destroy(this.gameObject, 0.5f);
                }
            }
            else
            {
                RemoveInventoryCell();
               // InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
               //Destroy(this.gameObject, 0.5f);
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
