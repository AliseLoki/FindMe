using UnityEngine;

public class GarbageContainer : InteractableObject
{
    protected override void UseObject()
    {
        int throwingFoodSoundEffectIndex = 0;

        if (Player.HasSomethingInHands && !Player.HasWood)
        {
            if (Player.PlayerCookingModule.CookingRecipeSO != null)
            {
                DeliveryServiceView.SetHasBeenCooked(Player.PlayerCookingModule.CookingRecipeSO);
            }

            PlaySoundEffect(AudioClipsList[throwingFoodSoundEffectIndex]);
            Player.PlayerCookingModule.ThrowFood();
            TipsViewPanel.ShowThrowFoodTip();
        }
        else if (Player.HasWood)
        {
            PlaySoundEffect(AudioClipsList[throwingFoodSoundEffectIndex]);
            Player.ResetWoodPrefab();
            TipsViewPanel.ShowThrowFoodTip();
        }
        else if (!Player.HasWood)
        {
            TipsViewPanel.ShowNothingInHandsTip();
        }
    }
}
