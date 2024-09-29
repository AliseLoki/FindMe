using System.Collections;
using UnityEngine;

public class RussianOven : Table
{
    [SerializeField] private bool _hasFire;

    [SerializeField] private FoodSO _uncookedFoodInPotFoodSO;
    [SerializeField] private FoodSO _cookedFoodInPotFoodSO;
    [SerializeField] private FoodSO _burnedFoodInPot;

    [SerializeField] private PlaceForWood _placeForWood;
    [SerializeField] private ParticleSystem _smokeEffect;

    private CookingRecipeSO _cookingRecipeSO;
    private StateOfReadyness _stateOfReadyness;
    private Coroutine _cookCoroutine;

    private void OnEnable()
    {
        DeliveryService.AllDishesHaveBeenDelivered += PutOutTheFire;
    }

    private void OnDisable()
    {
        DeliveryService.AllDishesHaveBeenDelivered -= PutOutTheFire;
    }

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
        int cookingSoundEffectIndex = 0;

        if ((_hasFire) && _uncookedFoodInPotFoodSO == Player.PlayerCookingModule.FoodSO)
        {
            PlaySoundEffect(AudioClipsList[cookingSoundEffectIndex]);
            FoodSO = Player.PlayerCookingModule.FoodSO;
            Food = Player.PlayerCookingModule.Food;
            _cookingRecipeSO = Player.PlayerCookingModule.CookingRecipeSO;
            Player.PlayerCookingModule.Food.SetInParent(PlaceForFood.transform);
            Player.PlayerCookingModule.GiveFood();
            _cookCoroutine = StartCoroutine(CookingCountDownRoutine());
            TipsViewPanel.ShowReadynessInstruction();
        }
        else if (!_hasFire && Player.PlayerHands.HasWood)
        {
            _hasFire = true;
            _placeForWood.LightFire(true);
            DisableInteract();
            Player.ResetWoodPrefab();
            TipsViewPanel.ShowCanUseOvenTip();
        }
        else if (!_hasFire && !Player.PlayerHands.HasWood)
        {
            TipsViewPanel.ShowNoWoodsTip();
        }
    }

    private void PutOutTheFire()
    {
        _placeForWood.LightFire(false);
        _hasFire = false;
    }

    private void TakePot()
    {
        int gettingFoodSoundEffectIndex = 1;

        PlaySoundEffect(AudioClipsList[gettingFoodSoundEffectIndex]);
        Food.SetInParent(Player.HandlePoint);
        Player.PlayerCookingModule.SetFood(Food, FoodSO);
        Player.SetHasSomethingInHands(true);
        Player.PlayerCookingModule.SetCookingRecipe(_cookingRecipeSO);
        Player.PlayerCookingModule.SetCookingRecipeStateOfRedyness(_stateOfReadyness);
        _smokeEffect.gameObject.SetActive(false);
        ResetFoodAndFoodSO();
        TipsViewPanel.ShowTimeToPack();
    }

    private IEnumerator CookingCountDownRoutine()
    {
        int pause = 4;
        _stateOfReadyness = 0;
        yield return new WaitForSeconds(pause);

        _stateOfReadyness++;
        ChangeOnePoTToAnother(_cookedFoodInPotFoodSO);
        yield return new WaitForSeconds(pause);

        _stateOfReadyness++;
        ChangeOnePoTToAnother(_burnedFoodInPot);
        _smokeEffect.gameObject.SetActive(true);
        _cookCoroutine = null;
    }

    private void ChangeOnePoTToAnother(FoodSO newFoodSO)
    {
        Destroy(Food.gameObject);
        FoodSO = newFoodSO;
        Food = Instantiate(newFoodSO.Prefab, PlaceForFood);
    }
}
