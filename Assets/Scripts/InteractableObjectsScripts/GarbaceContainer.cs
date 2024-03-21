using UnityEngine;

public class GarbageContainer : InteractableObject
{
    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands)
        {
            Player.Instance.ThrowFood();
        }

        if(Player.Instance.HasBackPack)
        {
            Player.Instance.ShowOrHideBackPack(false);
        }
    }
}
