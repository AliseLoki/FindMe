using UnityEngine;

public class GarbageContainer : InteractableObject
{
    protected override void UseObject()
    {
        if (Player.HasSomethingInHands && !Player.HasWood )
        {
            if(Player.PlayerCookingModule.CookingRecipeSO!= null)
            {
                DeliveryServiceView.SetHasBeenCooked(Player.PlayerCookingModule.CookingRecipeSO);
            }

            Player.PlayerCookingModule.ThrowFood();
            SoundEffects.PlayThwrowingFoodSoundEffect(transform);
            TipsViewPanel.ShowThrowFoodTip();
        }
        else
        {
            if(!Player.HasWood)
            TipsViewPanel.ShowNothingInHandsTip();
        }
    }
}
