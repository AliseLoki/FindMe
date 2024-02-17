using UnityEngine;

public abstract  class Table : InteractableObject
{
    [SerializeField] protected Transform _placeForFood;

    protected FoodSO _foodOnTheTableSO;
    protected Food _food;

    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands && _foodOnTheTableSO == null)
        {
            PutFoodOnTheTable();
        }
        else if (_foodOnTheTableSO != null)
        {
            DoSomething();
        }
        else
        {
            print("no food in hands ");
        }
    }

    protected abstract void DoSomething();

    protected abstract void PutFoodOnTheTable();
}
