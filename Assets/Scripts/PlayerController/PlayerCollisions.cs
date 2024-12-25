using System;
using UnityEngine;
using Trigger;
using Interactables;
using SoundSystem;
using SaveSystem;
using Enemies;
using Indexes;

namespace PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TipsViewPanel _tipsViewPanel;
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

            if (other.TryGetComponent(out ForestTrigger forestTrigger))
            {
                _music.PlayForestMusic();
                EnteredTheForest?.Invoke();
            }

            if (other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
            {
                EnteredSafeZone?.Invoke();
                _tipsViewPanel.gameObject.SetActive(true);
                _tipsViewPanel.ShowYouAreSafeTip();
                _music.PlayGrannysHomeMusic();
                _gameStatesSwitcher.OnPlayerEnteredGrannysHome();
            }

            if (other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
            {
                _music.PlayVilageMusic();
                EnteredSafeZone?.Invoke();
            }

            if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
            {
                _music.PlaySafeZoneMusic();
                _saveData.Save();
                EnteredSafeZone?.Invoke();
            }

            if (other.TryGetComponent(out PlaceForPentagramTrigger placeForPentagramTrigger))
            {
                _music.PlayPentagramMusic();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
            {
                _tipsViewPanel.ShowYouAreNotSafeTip();
                _music.PlayRoadMusic();
            }

            if (other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
            {
                _tipsViewPanel.ShowYouAreNotSafeTip();
            }

            if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
            {
                _tipsViewPanel.ShowYouAreNotSafeTip();
                _music.PlayRoadMusic();
            }

            if (other.TryGetComponent(out PlaceForPentagramTrigger placeForPentagramTrigger))
            {
                _music.PlayRoadMusic();
            }
        }
    }
}
