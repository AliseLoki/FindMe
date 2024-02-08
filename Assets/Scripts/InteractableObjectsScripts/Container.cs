using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] private FoodSO _foodSO;

    protected override void UseObject()
    {
        if (!Player.Instance.HasSomethingInHands)
        {
            print("����� �������");
            Food food = Instantiate(_foodSO.Prefab, Player.Instance.HandlePoint);
            Player.Instance.SetHasSomethingInHands(true);
            Player.Instance.SetFood(food);
        }
        else
        {
            print("� ����� ��� ���� �������");
        }
    }
}
