using System.Collections.Generic;
using UnityEngine;

public class PackingPlace : GarbageContainer
{
    [SerializeField] private List<FoodSO> _canBePackedRecipeSO;
    [SerializeField] private List<CookingRecipeSO> _packedDishes;
    [SerializeField] private Transform _package;

    private int _packageCapacity = 2;

    public void ShowPackage(bool isShowed)
    {
        _package.gameObject.SetActive(isShowed);
    }

    protected override void UseObject()
    {
        CheckPackageCapacity();

        if (_packedDishes.Count < _packageCapacity)
        {
            foreach (var item in _canBePackedRecipeSO)
            {
                if (Player1.FoodInHandsSO == item)
                {
                    _packedDishes.Add(Player1.CookedRecipeSODish);
                    Player1.ResetCookingRecipeSO();
                    Player1.ThrowFood();

                    foreach (var dish in _packedDishes)
                    {
                        print(dish.RecipeName + " - " + dish.Readyness);
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChekIfHandsAreFree();
            }
        }
    }

    private void ChekIfHandsAreFree()
    {
        if (Player1.HasSomethingInHands || Player1.HasBackPack)
        {
            TipsViewPanel.Instance.ShowHandsAreFullTip();
        }
        else
        {
            ShowPackage(false);
            Player1.SetDishesForDeliver(_packedDishes);
            Player1.ShowOrHideBackPack(true);
        }
    }

    private void CheckPackageCapacity()
    {
        if(_packedDishes.Count>=_packageCapacity)
        {
            TipsViewPanel.Instance.ShowNoPlaceTip();
        }
    }
}
