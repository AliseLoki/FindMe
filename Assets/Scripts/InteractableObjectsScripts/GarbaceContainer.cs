using UnityEngine;

public class GarbageContainer : InteractableObject
{
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private PackingPlace _packingPlace;

    protected override void UseObject()
    {
        if (Player1.HasSomethingInHands)
        {
            Player1.ThrowFood();
            _soundEffects.PlayThwrowingFoodSoundEffect(transform);

            TipsViewPanel.Instance.ShowThrowFoodTip();
        }
        else if (Player1.HasBackPack)
        {
            _packingPlace.ShowPackage(true);
            Player1.ShowOrHideBackPack(false);
            TipsViewPanel.Instance.ShowThrowFoodTip();
        }
        else
        {
            TipsViewPanel.Instance.ShowNothingToThrowTip();
        }
    }
}
