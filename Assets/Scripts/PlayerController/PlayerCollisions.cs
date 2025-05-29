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
        [SerializeField] private Player _player;
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

            if (other.TryGetComponent(out Trigger trigger))
            {
                switch (trigger.TriggerType)
                {
                    case TriggerTypes.Forest:
                        {
                            _music.PlayForestMusic();
                            EnteredTheForest?.Invoke();
                        }

                        break;

                    case TriggerTypes.GrannysHome:
                        {
                            EnteredSafeZone?.Invoke();
                            _gameStatesSwitcher.OnPlayerEnteredGrannysHome();
                            _music.PlayMusic(trigger.Clip);
                        }

                        break;

                    case TriggerTypes.SafeZone:
                        {
                            _saveData.Save();
                            EnteredSafeZone?.Invoke();
                            _music.PlayMusic(trigger.Clip);
                        }

                        break;

                    case TriggerTypes.VillageZone:
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
            if (other.TryGetComponent(out Trigger trigger))
            {
                switch (trigger.TriggerType)
                {
                    case TriggerTypes.GrannysHome:
                    case TriggerTypes.SafeZone:
                    case TriggerTypes.VillageZone:
                    case TriggerTypes.PlaceWithPentagram:
                        {
                            _music.PlayRoadMusic();
                        }

                        break;
                }
            }
        }
    }
}