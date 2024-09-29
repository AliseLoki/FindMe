using UnityEngine;

public class Well : InteractableObject
{
    [SerializeField] private Transform _bucketOfWater;

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
                _bucketOfWater.gameObject.SetActive(false);
                Player.TakeWater();
                TipsViewPanel.ShowWaterPatchTip();
            }

            _isPaid = false;
            _bucketOfWater.gameObject.SetActive(true);
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
