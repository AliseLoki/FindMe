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
            if (Input.GetMouseButtonDown(0))
            {
                ChekIfHandsAreFree();
            }
        }
    }

    private void ChekIfHandsAreFree()
    {
        if (Player.Instance.HasSomethingInHands || Player.Instance.HasBackPack)
        {
            TipsViewPanel.Instance.ShowHandsAreFullTip();
        }
        else
        {
            ShowPackage(false);
            Player.Instance.SetDishesForDeliver(_packedDishes);
            Player.Instance.ShowOrHideBackPack(true);
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
