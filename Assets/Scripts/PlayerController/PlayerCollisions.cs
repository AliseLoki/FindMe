using Enemies;
using GameControllers;
using Indexes;
using Interactables;
using SaveSystem;
using SoundSystem;
using System;
using Triggers;
using UIPanels;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TipsViewPanel _tipsViewPanel;
        [SerializeField] private Music _music;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private SaveData _saveData;

        private TriggerTypes _triggerType;

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
                            _tipsViewPanel.gameObject.SetActive(true);
                            _tipsViewPanel.ShowYouAreSafeTip();
                            _music.PlayGrannysHomeMusic();
                            _gameStatesSwitcher.OnPlayerEnteredGrannysHome();
                        }
                        break;

                    case TriggerTypes.PlaceWithPentagram:
                        {
                            _music.PlayPentagramMusic();
                        }
                        break;

                    case TriggerTypes.SafeZone:
                        {
                            _music.PlaySafeZoneMusic();
                            _saveData.Save();
                            EnteredSafeZone?.Invoke();
                        }
                        break;

                    case TriggerTypes.VillageZone:
                        {
                            _music.PlayVilageMusic();
                            EnteredSafeZone?.Invoke();
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
                            _tipsViewPanel.ShowYouAreNotSafeTip();
                            _music.PlayRoadMusic();
                        }
                        break;
                }
            }
        }
    }
}