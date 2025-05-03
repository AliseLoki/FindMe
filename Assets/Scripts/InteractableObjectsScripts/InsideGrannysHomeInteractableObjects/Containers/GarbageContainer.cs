namespace Interactables.Containers
{
    public class GarbageContainer : InteractableObject
    {
        protected override void UseObject()
        {
            if (Player.PlayerHands.HasSomethingInHands && Player.PlayerHands.InventoryPrefabSO == null)
            {
                if (Player.PlayerCookingModule.CookingRecipeSO != null)
                {
                    DeliveryServiceView.SetHasBeenCooked(Player.PlayerCookingModule.CookingRecipeSO);
                }

                Player.PlayerCookingModule.GiveFood();
                Player.PlayerHands.GiveObject();
                Player.PlayerSoundEffects.PlaySoundEffect(Clip);

            }
        }
    }
}