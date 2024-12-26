using UnityEngine;
using SaveSystem;

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
            int payingForWaterSoundEffectIndex = 0;

            if (!Player.PlayerHands.HasSomethingInHands)
            {
                PayForBucketOfWater();

                if (_isPaid)
                {
                    PlaySoundEffect(AudioClipsList[payingForWaterSoundEffectIndex]);
                    Player.PlayerHands.TakeObject(_bucketOfWater.gameObject, _bucketOfWater.HoldableObjects);
                    TipsViewPanel.ShowWaterPatchTip();
                }

                _isPaid = false;
            }
            else
            {
                TipsViewPanel.ShowHandsAreFullTip();
            }
        }

        private void PayForBucketOfWater()
        {
            if (Player.PlayerGold.CheckIfCanPay(_price))
            {
                _isPaid = true;
            }
            else
            {
                TipsViewPanel.ShowNotEnoughMoneyTip();
            }
        }
    }
}
