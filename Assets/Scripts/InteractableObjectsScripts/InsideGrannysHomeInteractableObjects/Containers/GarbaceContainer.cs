using UnityEngine;

public class GarbageContainer : InteractableObject
{
    protected override void UseObject()
    {
        int throwingFoodSoundEffectIndex = 0;

        if (Player.PlayerHands.HasSomethingInHands && !Player.PlayerHands.HasWood)
        {
            if (Player.PlayerCookingModule.CookingRecipeSO != null)
            {
                DeliveryServiceView.SetHasBeenCooked(Player.PlayerCookingModule.CookingRecipeSO);
            }

            PlaySoundEffect(AudioClipsList[throwingFoodSoundEffectIndex]);
            Player.PlayerCookingModule.ThrowFood();
            TipsViewPanel.ShowThrowFoodTip();
        }
        else if (Player.PlayerHands.HasWood)
        {
            PlaySoundEffect(AudioClipsList[throwingFoodSoundEffectIndex]);
            Player.PlayerHands.ResetWoodPrefab();
            TipsViewPanel.ShowThrowFoodTip();
        }
        else if (!Player.PlayerHands.HasWood)
        {
            TipsViewPanel.ShowNothingInHandsTip();
        }
    }
}
