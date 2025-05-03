using GameControllers;
using Indexies;
using PlayerController;
using SO;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryViewHandler
{
    [RequireComponent(typeof(Button))]
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private Image _inventoryCellImage;
        [SerializeField] private Player _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

        private InventoryPrefabSO _inventoryPrefabSO;

        public event Action<InventoryPrefabSO> InventoryCellButtonPressed;

        public void InitLinks(Player player, GameStatesSwitcher gameStatesSwitcher)
        {
            _player = player;
            _gameStatesSwitcher = gameStatesSwitcher;
        }

        public void SetInventoryCellImage(InventoryPrefabSO inventoryPrefabSO)
        {
            _inventoryCellImage.sprite = inventoryPrefabSO.Sprite;
            _inventoryPrefabSO = inventoryPrefabSO;
        }

        public void OnInventoryCellButtonPressed()
        {
            if (!_player.PlayerHands.HasSomethingInHands)
            {
                if (_inventoryPrefabSO.InventoryPrefab.Type == InventoryPrefabType.Necronomicon)
                {
                    if (_gameStatesSwitcher.IsWitchAppeared())
                    {
                        RemoveInventoryCell();
                    }
                }
                else
                {
                    RemoveInventoryCell();
                }
            }
        }

        private void RemoveInventoryCell()
        {
            InventoryCellButtonPressed?.Invoke(_inventoryPrefabSO);
            Destroy(this.gameObject, 0.5f);
        }
    }
}