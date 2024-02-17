using UnityEngine;

public class CookingTable : Table
{
    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("CHECK COOK");
        }
    }

    protected override void PutFoodOnTheTable()
    {
        
    }
}
