using UnityEngine;

public class GarbageContainer : InteractableObject
{
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private PackingPlace _packingPlace;

    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands)
        {
            Player.Instance.ThrowFood();
            _soundEffects.PlayThwrowingFoodSoundEffect(transform);

            TipsViewPanel.Instance.ShowThrowFoodTip();
        }
        else if (Player.Instance.HasBackPack)
        {
            _packingPlace.ShowPackage(true);
            Player.Instance.ShowOrHideBackPack(false);
            TipsViewPanel.Instance.ShowThrowFoodTip();
        }
        else
        {
            TipsViewPanel.Instance.ShowNothingToThrowTip();
        }
    }
}
