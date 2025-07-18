using System.Collections;
using System.Collections.Generic;
using Indexies;
using LeaderboardSystem;
using SO;
using UnityEngine;

namespace Interactables
{
    public class House : InteractableObject
    {
        [SerializeField] private CookingRecipeSO _expectedCookingRecipeSO;
        [SerializeField] private Transform _placeForSpawnedObject;
        [SerializeField] private Transform _deliveredPackage;
        [SerializeField] private GoldCoins _goldCoins;
        [SerializeField] private DeliveredDishesCounter _deliveredDishesCounter;
        [SerializeField] private HouseIndex _houseIndex;
        [SerializeField] private List<AudioClip> _clips;

        private bool _isDelivered;

        private StateOfReadyness _readyness = StateOfReadyness.Cooked;

        public bool IsDelivered => _isDelivered;

        public HouseIndex Index => _houseIndex;

        public void InitIsDelivered()
        {
            _isDelivered = true;
        }

        protected override void UseObject()
        {
            int puttingSoundEffectIndex = 0;

            if (Player.PlayerHands.HasBackPack)
            {
                var deliveredDish = DeliveryService.CheckEquality(_expectedCookingRecipeSO);

                if (deliveredDish != null)
                {
                    Player.PlayerSoundEffects.PlaySoundEffect(_clips[puttingSoundEffectIndex]);
                    SpawnObject(_deliveredPackage.gameObject);
                    StartCoroutine(CheckReadynessOfDishe(deliveredDish));
                    _isDelivered = true;
                }
            }
        }

        private IEnumerator CheckReadynessOfDishe(CookingRecipeSO cookingRecipeSO)
        {
            int goldAppearSoundEffectIndex = 1;

            yield return PayCountDownRoutine();

            if (cookingRecipeSO.Readyness == _readyness)
            {
                Player.PlayerSoundEffects.PlaySoundEffect(_clips[goldAppearSoundEffectIndex]);
                SpawnObject(_goldCoins.gameObject);
                _deliveredDishesCounter.AddDeliveredDish();
            }

            _deliveredDishesCounter.AddDeliveredDish();
            DeliveryService.RemoveDeliveredDish(cookingRecipeSO);
        }

        private void SpawnObject(GameObject spawnedObject)
        {
            Instantiate(spawnedObject, _placeForSpawnedObject);
        }

        private IEnumerator PayCountDownRoutine()
        {
            int pause = 1;
            yield return new WaitForSeconds(pause);
            Destroy(_placeForSpawnedObject.GetChild(0).gameObject);
        }
    }
}