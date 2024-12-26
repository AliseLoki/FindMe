using Indexes;
using Interactables.Containers;
using Interactables.InventoryPrefabs;
using SO;
using UnityEngine;

namespace Interactables.Patches
{
    public class Patch : InteractableObject
    {
        [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;
        [SerializeField] private Transform _grass;
        [SerializeField] private Transform _vegetable;
        [SerializeField] private Container _barrelWithIngredients;
        [SerializeField] private Well _well;

        public Container BarrelWithIngredients => _barrelWithIngredients;
        public Transform Grass => _grass;

        protected override void UseObject()
        {
            int wateringSoundEffectIndex = 0;
            int throwingSoundEffect = 1;

            if (Player.PlayerHands.HoldableObject == HoldableObjectType.Water)
            {
                if (_grass.gameObject.activeSelf)
                {
                    _vegetable.gameObject.SetActive(true);
                    _barrelWithIngredients.gameObject.SetActive(true);
                    ShowYouHaveNewIngredientTips();
                }

                Player.PlayerHands.GiveObject();
                PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
                _well.DrawWater();
            }
            else if (Player.PlayerHands.HoldableObject == HoldableObjectType.CabbageForSeeds ||
                Player.PlayerHands.HoldableObject == HoldableObjectType.TomatoForSeeds ||
                Player.PlayerHands.HoldableObject == HoldableObjectType.Cow)
            {
                if (!_grass.gameObject.activeSelf && _inventoryPrefabSO == Player.PlayerHands.InventoryPrefabSO)
                {
                    PlaySoundEffect(AudioClipsList[throwingSoundEffect]);
                    Player.PlayerHands.GiveObject();
                    _grass.gameObject.SetActive(true);
                    DisableInteract();
                    ShowBringWaterTip();
                }
            }
        }

        private void ShowYouHaveNewIngredientTips()
        {
            if (_inventoryPrefabSO.InventoryPrefab as Cow)
            {
                TipsViewPanel.ShowNowYouHaveCheeseTip();
            }
            else if (_inventoryPrefabSO.InventoryPrefab as CabbageForSeeds || _inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
            {
                TipsViewPanel.ShowNowYouHaveNewVegetableTip();
            }
        }

        private void ShowBringWaterTip()
        {
            if (_inventoryPrefabSO.InventoryPrefab as Cow)
            {
                TipsViewPanel.ShowGiveMeAWaterTip();
            }
            else if (_inventoryPrefabSO.InventoryPrefab as CabbageForSeeds || _inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
            {
                TipsViewPanel.ShowBringWaterHere();
            }
        }
    }
}
