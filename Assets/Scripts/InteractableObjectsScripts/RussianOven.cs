using System.Collections;
using UnityEngine;

public class RussianOven : Table
{
    [SerializeField] private bool _hasFire ;

    [SerializeField] private FoodSO _uncookedFoodInPot;
    [SerializeField] private FoodSO _cookedFoodInPot;
    [SerializeField] private FoodSO _burnedFoodInPot;
    [SerializeField] private PlaceForWood _placeForOven;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private SoundEffects _soundEffects;
    
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
        if (_hasFire && _uncookedFoodInPot == Player1.FoodInHandsSO)
        {
            FoodOnTheTableSO = Player1.FoodInHandsSO;
            _food = Player1.FoodInHands;
            Player1.FoodInHands.SetInParent(_placeForFood);
            Player1.GiveFood();
            _cookCoroutine = StartCoroutine(CookingCountDownRoutine());
            _soundEffects.PlayCookingFoodSoundEffect(transform);
            TipsViewPanel.Instance.ShowReadynessInstruction();
        }
        else if (!_hasFire && !Player1.HasWood)
        {
           TipsViewPanel.Instance.ShowNoWoodsTip();
        }
        else if(!_hasFire && Player1.HasWood && !Player1.HasSomethingInHands)
        {
            _hasFire = true;
            _placeForOven.LightFire(true);
            TipsViewPanel.Instance.ShowCanUseOvenTip();
        }
        else if(!_hasFire && Player1.HasWood && Player1.HasSomethingInHands)
        {
            TipsViewPanel.Instance.ShowCantLightFire();
        }     
    }

    private void TakePot()
    {
        _food.SetInParent(Player1.HandlePoint);
        Player1.SetFood(_food, FoodOnTheTableSO);
        Player1.SetHasSomethingInHands(true);
        Player1.SetCookingRecipeStateOfRedyness(_stateOfReadyness);
        print(_stateOfReadyness);
        _smokeEffect.gameObject.SetActive(false);    
        ResetFoodAndFoodSO();
        _soundEffects.PlayGettingFoodSoundEffect(transform);
        TipsViewPanel.Instance.ShowTimeToPack();
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
