using System.Collections;
using Indexies;
using SO;
using UnityEngine;

namespace Interactables.Containers.Tables
{
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

            if (_hasFire && _uncookedFoodInPotFoodSO == Player.PlayerCookingModule.FoodSO)
            {
                IniTFoodAndFoodSO(Player.PlayerCookingModule.Food, Player.PlayerCookingModule.FoodSO);
                _cookingRecipeSO = Player.PlayerCookingModule.CookingRecipeSO;
                Player.PlayerCookingModule.Food.SetInParent(PlaceForFood.transform);
                Player.PlayerCookingModule.GiveFood();
                Player.PlayerHands.GiveObject();
                _cookCoroutine = StartCoroutine(CookingCountDownRoutine());
                Player.PlayerSoundEffects.PlaySoundEffect(AudioClips[cookingSoundEffectIndex]);
            }
            else if (!_hasFire && Player.PlayerHands.HoldableObject == HoldableObjectType.Wood)
            {
                _hasFire = true;
                _placeForWood.LightFire(true);
                DisableInteract();
                Player.PlayerHands.GiveObject();
                Player.PlayerSoundEffects.PlayTakingWoodSoundEffect();
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

            Food.SetInParent(Player.PlayerHands.HandlePoint);
            Player.PlayerHands.TakeObject(Food.gameObject, Food.ConnectedFoodSO.Type);
            Player.PlayerCookingModule.SetFood(Food, FoodSO);
            Player.PlayerCookingModule.SetCookingRecipe(_cookingRecipeSO);
            Player.PlayerCookingModule.SetCookingRecipeStateOfRedyness(_stateOfReadyness);
            ResetFoodAndFoodSO();
            _smokeEffect.gameObject.SetActive(false);
            Player.PlayerSoundEffects.PlaySoundEffect(AudioClips[gettingFoodSoundEffectIndex]);
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
            Food = Instantiate(newFoodSO.Prefab, PlaceForFood).GetComponent<Food>();
        }
    }
}