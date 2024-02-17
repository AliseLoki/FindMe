using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] private FoodSO _foodSO;
    [SerializeField] private Food _food;

    protected override void UseObject()
    {
        if (!Player.Instance.HasSomethingInHands)
        {
            print("����� �������");
           
            _food = Instantiate(_foodSO.Prefab, Player.Instance.HandlePoint);         
            Player.Instance.SetHasSomethingInHands(true);
            Player.Instance.SetFood(_food,_foodSO);
        }
        else
        {
            print("� ����� ��� ���� �������");
        }
    }
}
