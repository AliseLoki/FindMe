using UnityEngine;

public class Well : InteractableObject
{
    [SerializeField] private BucketOfWater _bucketOfWater;

    private bool _isPaid;
    private int _price = 10;

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
            //по идее должно появляться, когда игрок вылил воду
           // _bucketOfWater.gameObject.SetActive(true);
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }

    private void PayForBucketOfWater()
    {
        if (Player.PlayerEventsHandler.CheckIfCanPay(_price))
        {
            _isPaid = true;
        }
        else
        {
            TipsViewPanel.ShowNotEnoughMoneyTip();
        }
    }
}
