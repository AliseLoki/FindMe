using System;
using Enemies;
using GameControllers;
using Indexies;
using Interactables;
using SaveSystem;
using SoundSystem;
using Triggers;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private PlayerOld _player;
        [SerializeField] private Music _music;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private SaveData _saveData;

        public event Action EnteredTheForest;
        public event Action EnteredSafeZone;
        public event Action WolfHasBeenKilled;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
            {
                interactableObject.EnableInteract();
            }

            if (collision.collider.TryGetComponent(out Enemy enemy) && _player.PlayerHands.HoldableObject == HoldableObjectType.Sword)
            {
                WolfHasBeenKilled?.Invoke();
                _player.PlayerHands.GiveObject();
            }

            if (collision.collider.TryGetComponent(out Witch witch))
            {
                if (_player.PlayerHands.HoldableObject == HoldableObjectType.Necronomicon)
                {
                    witch.Die();
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
            {
                interactableObject.DisableInteract();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GoldCoins goldCoins))
            {
                goldCoins.PickUpCoins();
                _player.PlayerGold.OnGoldAmountChanged(goldCoins.CoinsValue);
            }

            if (other.TryGetComponent(out TriggerOld trigger))
            {
                switch (trigger.TriggerType)
                {
                    case TriggerTypesOld.Forest:
                        {
                            _music.PlayForestMusic();
                            EnteredTheForest?.Invoke();
                        }

                        break;

                    case TriggerTypesOld.GrannysHome:
                        {
                            EnteredSafeZone?.Invoke();
                            _gameStatesSwitcher.OnPlayerEnteredGrannysHome();
                            _music.PlayMusic(trigger.Clip);
                        }

                        break;

                    case TriggerTypesOld.SafeZone:
                        {
                            _saveData.Save();
                            EnteredSafeZone?.Invoke();
                            _music.PlayMusic(trigger.Clip);
                        }

                        break;

                    case TriggerTypesOld.VillageZone:
                        {
                            EnteredSafeZone?.Invoke();
                            _music.PlayMusic(trigger.Clip);
                        }

                        break;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TriggerOld trigger))
            {
                switch (trigger.TriggerType)
                {
                    case TriggerTypesOld.GrannysHome:
                    case TriggerTypesOld.SafeZone:
                    case TriggerTypesOld.VillageZone:
                    case TriggerTypesOld.PlaceWithPentagram:
                        {
                            _music.PlayRoadMusic();
                        }

                        break;
                }
            }
        }
    }
}