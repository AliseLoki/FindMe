namespace Interactables.Containers
{
    public class GarbageContainer : InteractableObject
    {
        protected override void UseObject()
        {
            int throwingFoodSoundEffectIndex = 0;

            if (Player.PlayerHands.HasSomethingInHands && Player.PlayerHands.InventoryPrefabSO == null)
            {
                if (Player.PlayerCookingModule.CookingRecipeSO != null)
                {
                    DeliveryServiceView.SetHasBeenCooked(Player.PlayerCookingModule.CookingRecipeSO);
                }

                Player.PlayerCookingModule.GiveFood();
                Player.PlayerHands.GiveObject();

               // PlaySoundEffect(AudioClipsList[throwingFoodSoundEffectIndex]);
               // TipsViewPanel.ShowThrowFoodTip();
            }
            else
            {
               // TipsViewPanel.ShowNothingInHandsTip();
            }
        }
    }
}
