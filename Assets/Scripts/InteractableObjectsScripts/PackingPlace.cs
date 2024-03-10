using System.Collections.Generic;
using UnityEngine;

public class PackingPlace : GarbageContainer
{
    [SerializeField] List<FoodSO> _canBePackedRecipeSO;
    
    protected override void UseObject()
    {
        foreach (var item in _canBePackedRecipeSO)
        {
            if(Player.Instance.FoodInHandsSO == item)
            {
                Player.Instance.ThrowFood();
                print("”паковали");
            }
        }
    }
}
