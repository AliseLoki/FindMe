using UnityEngine;

public class GarbageContainer : InteractableObject
{
    [SerializeField] private SoundEffects _soundEffects;

    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands)
        {
            Player.Instance.ThrowFood();
            _soundEffects.PlayThwrowingFoodSoundEffect(transform);
        }

        if(Player.Instance.HasBackPack)
        {
            Player.Instance.ShowOrHideBackPack(false);
        }
    }
}
