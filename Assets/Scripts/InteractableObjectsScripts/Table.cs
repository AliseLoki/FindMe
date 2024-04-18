using UnityEngine;

public abstract class Table : InteractableObject
{
    [SerializeField] protected Transform _placeForFood;

    protected bool IsChangedFood;
    protected FoodSO FoodOnTheTableSO;
    protected Food _food;

    protected override void UseObject()
    {
        if (FoodOnTheTableSO == null && Player1.HasSomethingInHands)
        {
            PutFood();
        }
        else if (FoodOnTheTableSO != null && !Player1.HasSomethingInHands)
        {
            DoSomething();
        }
        else if (FoodOnTheTableSO != null && Player1.HasSomethingInHands)
        {
            TipsViewPanel.Instance.ShowHandsAreFullTip();
        }
        else if(this as RussianOven)
        {
            PutFood();
        }
    }

    protected abstract void DoSomething();

    protected abstract void PutFood();

    protected void ResetFoodAndFoodSO()
    {
        _food = null;
        FoodOnTheTableSO = null;
    }
}
