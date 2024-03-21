using System.Collections;
using UnityEngine;

public class RussianOven : Table
{
    [SerializeField] private bool _hasFire ;

    [SerializeField] private FoodSO _uncookedFoodInPot;
    [SerializeField] private FoodSO _cookedFoodInPot;
    [SerializeField] private FoodSO _burnedFoodInPot;
    [SerializeField] private PlaceForOven _placeForOven;

    [SerializeField] private ParticleSystem _smokeEffect;

    private StateOfReadyness _stateOfReadyness;
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
            FoodOnTheTableSO = Player.Instance.FoodInHandsSO;
            _food = Player.Instance.FoodInHands;
            Player.Instance.FoodInHands.SetInParent(_placeForFood);
            Player.Instance.GiveFood();
            _cookCoroutine = StartCoroutine(CookingCountDownRoutine());
        }
        else if (!_hasFire && !Player.Instance.HasWood)
        {
            print("Сначала нужно разжечь огонь");
        }
        else if(!_hasFire && Player.Instance.HasWood)
        {
            _hasFire = true;
            _placeForOven.LightFire(true);
        }
    }

    private void TakePot()
    {
        _food.SetInParent(Player.Instance.HandlePoint);
        Player.Instance.SetFood(_food, FoodOnTheTableSO);
        Player.Instance.SetHasSomethingInHands(true);
        Player.Instance.SetCookingRecipeStateOfRedyness(_stateOfReadyness);
        print(_stateOfReadyness);
        _smokeEffect.gameObject.SetActive(false);    
        ResetFoodAndFoodSO();
    }

    private IEnumerator CookingCountDownRoutine()
    {
        int pause = 4;
        _stateOfReadyness = 0;
        yield return new WaitForSeconds(pause);

        _stateOfReadyness++;
        ChangeOnePoTToAnother(_cookedFoodInPot);  
        yield return new WaitForSeconds(pause);

        _stateOfReadyness++;
        ChangeOnePoTToAnother(_burnedFoodInPot);
        _smokeEffect.gameObject.SetActive(true);
        _cookCoroutine = null;
    }

    private void ChangeOnePoTToAnother(FoodSO newFoodSO)
    {
        Destroy(_food.gameObject);
        FoodOnTheTableSO = newFoodSO;
        _food = Instantiate(newFoodSO.Prefab, _placeForFood);
    }
}
