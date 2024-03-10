using System.Collections;
using UnityEngine;

public class RussianOven : Table
{
    [SerializeField] private bool _hasFire ;

    [SerializeField] private FoodSO _uncookedFoodInPot;
    [SerializeField] private FoodSO _cookedFoodInPot;
    [SerializeField] private FoodSO _burnedFoodInPot;

    private Coroutine _cookCoroutine;

    protected override void DoSomething()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_cookCoroutine != null)
            {
                StopCoroutine(_cookCoroutine);
                _cookCoroutine = null;
            }

            TakePot();
        }
    }

    protected override void PutFood()
    {
        if (_hasFire && _uncookedFoodInPot == Player.Instance.FoodInHandsSO)
        {
            _foodOnTheTableSO = Player.Instance.FoodInHandsSO;
            _food = Player.Instance.FoodInHands;
            Player.Instance.FoodInHands.SetInParent(_placeForFood);
            Player.Instance.GiveFood();
            _cookCoroutine = StartCoroutine(CookingCountDownRoutine());
        }
    }

    private void TakePot()
    {
        _food.SetInParent(Player.Instance.HandlePoint);
        Player.Instance.SetFood(_food, _foodOnTheTableSO);
        Player.Instance.SetHasSomethingInHands(true);
        _foodOnTheTableSO = null;
        _food = null;
    }

    private IEnumerator CookingCountDownRoutine()
    {
        int pause = 4;
        yield return new WaitForSeconds(pause);
        ChangeOnePoTToAnother(_cookedFoodInPot);       
        yield return new WaitForSeconds(pause);      
        ChangeOnePoTToAnother(_burnedFoodInPot);
        _cookCoroutine = null;
    }

    private void ChangeOnePoTToAnother(FoodSO newFoodSO)
    {
        Destroy(_food.gameObject);
        _foodOnTheTableSO = newFoodSO;
        _food = Instantiate(newFoodSO.Prefab, _placeForFood);
    }
}
