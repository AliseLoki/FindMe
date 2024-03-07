using UnityEngine;

public abstract  class Table : InteractableObject
{
    [SerializeField] protected Transform _placeForFood;

    protected bool _isChangedFood;
    protected FoodSO _foodOnTheTableSO;
    protected Food _food;

    protected override void UseObject()
    {
        if (Player.Instance.HasSomethingInHands && _foodOnTheTableSO == null )
        {
            PutFoodOnTheTable();
        }
        else if (_foodOnTheTableSO != null && !Player.Instance.HasSomethingInHands)
        {
            DoSomething();
            print("yyyyyyyyyy");
        }
        else if( _foodOnTheTableSO != null && Player.Instance.HasSomethingInHands) 
        {
            //print("������ �����������������, ���� ������");
        }
        else
        {
           // print("� ����� ������ ���");
        }
    }

    protected abstract void DoSomething();

    protected abstract void PutFoodOnTheTable();
}
