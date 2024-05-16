using UnityEngine;

public abstract class Table : Container
{
    [SerializeField] protected Transform PlaceForFood;

        protected bool IsChangedFood;
   
    protected override void UseObject()
    {
        if (FoodSO == null && Player.HasSomethingInHands)
        {
            PutFood();
        }
        else if (FoodSO != null && !Player.HasSomethingInHands)
        {
            DoSomething();
        }
        else if (FoodSO != null && Player.HasSomethingInHands)
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
        else if(FoodSO == null && !Player.HasSomethingInHands)
        {
            TipsViewPanel.ShowNothingInHandsTip();
        }
    }

    protected abstract void DoSomething();

    protected abstract void PutFood();

    protected void ResetFoodAndFoodSO()
    {
        Food = null;
        FoodSO = null;
    }
}
