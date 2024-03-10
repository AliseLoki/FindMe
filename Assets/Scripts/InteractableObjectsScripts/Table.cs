using UnityEngine;

public abstract class Table : InteractableObject
{
    [SerializeField] protected Transform _placeForFood;

    protected bool _isChangedFood;
    protected FoodSO _foodOnTheTableSO;
    protected Food _food;

    protected override void UseObject()
    {
        if (_foodOnTheTableSO == null && Player.Instance.HasSomethingInHands)
        {
            PutFood();
        }
        else if (_foodOnTheTableSO != null && !Player.Instance.HasSomethingInHands)
        {
            DoSomething();
        }
        else if (_foodOnTheTableSO != null && Player.Instance.HasSomethingInHands)
        {
            print("������ �����������������, ���� ������");
        }
        else
        {
            print("�� ������ ������");
        }
    }

    protected abstract void DoSomething();

    protected abstract void PutFood();
}
