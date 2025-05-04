using SaveSystem;
using UnityEngine;

namespace Interactables
{
    public class Well : InteractableObject
    {
        [SerializeField] private BucketOfWater _bucketOfWater;
        [SerializeField] private Spawner _spawner;

        private bool _isPaid;
        private int _price = 10;

        public void DrawWater()
        {
            _bucketOfWater = _spawner.SpawnBucketOfWaterInWell();
        }

        protected override void UseObject()
        {
            if (!Player.PlayerHands.HasSomethingInHands)
            {
                PayForBucketOfWater();

                if (_isPaid)
                {
                    Player.PlayerSoundEffects.PlaySoundEffect(Clip);
                    Player.PlayerHands.TakeObject(_bucketOfWater.gameObject, _bucketOfWater.HoldableObjects);
                }

                _isPaid = false;
            }
        }

        private void PayForBucketOfWater()
        {
            if (Player.PlayerGold.CheckIfCanPay(_price))
            {
                _isPaid = true;
            }
        }
    }
}
