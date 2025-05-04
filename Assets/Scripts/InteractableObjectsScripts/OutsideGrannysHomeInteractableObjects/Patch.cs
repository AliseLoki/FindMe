using Indexies;
using Interactables.Containers;
using SO;
using System.Collections.Generic;
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
        [SerializeField] private List<AudioClip> _clips;

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
                }

                Player.PlayerHands.GiveObject();
                Player.PlayerSoundEffects.PlaySoundEffect(_clips[wateringSoundEffectIndex]);
                _well.DrawWater();
            }
            else if (Player.PlayerHands.HoldableObject == HoldableObjectType.CabbageForSeeds ||
                Player.PlayerHands.HoldableObject == HoldableObjectType.TomatoForSeeds ||
                Player.PlayerHands.HoldableObject == HoldableObjectType.Cow)
            {
                if (!_grass.gameObject.activeSelf && _inventoryPrefabSO == Player.PlayerHands.InventoryPrefabSO)
                {
                    Player.PlayerSoundEffects.PlaySoundEffect(_clips[throwingSoundEffect]);
                    Player.PlayerHands.GiveObject();
                    _grass.gameObject.SetActive(true);
                    DisableInteract();
                }
            }
        }
    }
}
