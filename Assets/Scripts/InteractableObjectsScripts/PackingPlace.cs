using System.Collections.Generic;
using UnityEngine;

public class PackingPlace : GarbageContainer
{
    [SerializeField] private List<FoodSO> _canBePackedRecipeSO;
    [SerializeField] private List<CookingRecipeSO> _packedDishes;
    [SerializeField] private Transform _package;

    private int _packageCapacity = 3;

    protected override void UseObject()
    {
        if (_packedDishes.Count < _packageCapacity)
        {
            foreach (var item in _canBePackedRecipeSO)
            {
                if (Player.Instance.FoodInHandsSO == item)
                {
                    _packedDishes.Add(Player.Instance.CookedRecipeSODish);
                    Player.Instance.ResetCookingRecipeSO();
                    Player.Instance.ThrowFood();

                    foreach (var dish in _packedDishes)
                    {
                        print(dish.RecipeName + " - " + dish.Readyness);
                    }
                }
            }
        }
        else
        {
            print("В рюкзаке больше нет места, пора отправляться в дорогу");

            if (Input.GetMouseButtonDown(0))
            {
                ChekIfHandsAreFree();
            }
        }
    }

    private void ChekIfHandsAreFree()
    {
        if (Player.Instance.HasSomethingInHands)
        {
            print("сначала освободите руки");
        }
        else
        {
            _package.gameObject.SetActive(false);
            Player.Instance.SetDishesForDeliver(_packedDishes);
            Player.Instance.ShowBackPack();
        }
    }
}
