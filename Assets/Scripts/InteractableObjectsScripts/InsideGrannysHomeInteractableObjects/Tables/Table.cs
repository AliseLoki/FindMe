using UnityEngine;

public abstract class Table : Container
{
    [SerializeField] protected Transform PlaceForFood;

        protected bool IsChangedFood;
   
    protected override void UseObject()
    {
        if (FoodSO == null && Player.PlayerHands.HasSomethingInHands)
        {
            PutFood();
        }
        else if (FoodSO != null && !Player.PlayerHands.HasSomethingInHands)
        {
            DoSomething();
        }
        else if (FoodSO != null && Player.PlayerHands.HasSomethingInHands)
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
        else if(FoodSO == null && !Player.PlayerHands.HasSomethingInHands)
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

    protected void IniTFoodAndFoodSO(Food food,FoodSO foodSO)
    {
        Food = food;
        FoodSO = foodSO; 
    }
}
