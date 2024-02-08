using UnityEngine;

public class GarbageContainer : InteractableObject
{
    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands)
        {
            print("выбрось продукт");
            Player.Instance.ThrowFood();
        }
        else
        {
            print("в руках нет продуктов");
        }
    }
}
