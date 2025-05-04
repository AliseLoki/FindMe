using SO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables.Containers.Tables
{
    public class CookingTable : Table
    {
        [SerializeField] private ChangingFoodRecipeSO[] _ingredientsForCooking;
        [SerializeField] private Food[] _tableFoodPrefabs;
        [SerializeField] private List<FoodSO> _onTheTableFoodSO = new List<FoodSO>();
        [SerializeField] private Food _foodPotPrefab;

        private CookingRecipeSO _cookingRecipeSO;

        public event Action<CookingRecipeSO> CanBeCookedCookingRecipeSO;

        private void OnEnable()
        {
            DeliveryServiceView.DishPrepared += OnDishPrepared;
        }

        private void OnDisable()
        {
            DeliveryServiceView.DishPrepared -= OnDishPrepared;
        }

        protected override void DoSomething()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GivePotToPlayer();
                ResetFoodAndFoodSO();
                CheckIfCanCook();
                Player.PlayerCookingModule.SetCookingRecipe(_cookingRecipeSO);
            }
        }

        protected override void PutFood()
        {
            bool hasMatch = false;
            int puttingFoodSoundEffectIndex = 0;

            CheckIfCanPutFoodOnTheTable(hasMatch, puttingFoodSoundEffectIndex);
            CheckIfCanCook();
        }

        private void CheckIfCanPutFoodOnTheTable(bool hasMatch, int puttingFoodSoundEffectIndex)
        {
            foreach (ChangingFoodRecipeSO changingFoodRecipeSO in _ingredientsForCooking)
            {
                if (changingFoodRecipeSO.Output == Player.PlayerCookingModule.FoodSO)
                {
                    ShowFoodOnTheTable();
                    SetToTheTableListFoodSO(Player.PlayerCookingModule.FoodSO);
                    Player.PlayerHands.GiveObject();
                    Player.PlayerCookingModule.GiveFood();
                    Player.PlayerSoundEffects.PlaySoundEffect(AudioClips[puttingFoodSoundEffectIndex]);
                    hasMatch = true;
                }
            }
        }

        private void OnDishPrepared(CookingRecipeSO cookingRecipeSO)
        {
            int mixingIngredientsSoundEffectIndex = 2;

            if (Food == null)
            {
                Player.PlayerSoundEffects.PlaySoundEffect(AudioClips[mixingIngredientsSoundEffectIndex]);
                SpawnPotOnTheTable();
            }

            _cookingRecipeSO = cookingRecipeSO;

            HideFoodOnTheTable(cookingRecipeSO);
        }

        private void SpawnPotOnTheTable()
        {
            Food = Instantiate(_foodPotPrefab, PlaceForFood.position, Quaternion.identity);
            FoodSO = Food.ConnectedFoodSO;
        }

        private void GivePotToPlayer()
        {
            int gettingFoodSoundEffectIndex = 1;
            Player.PlayerCookingModule.SetFood(Food, FoodSO);
            Player.PlayerHands.TakeObject(Food.gameObject, FoodSO.Type);
            Player.PlayerSoundEffects.PlaySoundEffect(AudioClips[gettingFoodSoundEffectIndex]);
        }

        private void SetToTheTableListFoodSO(FoodSO playerFoodSO)
        {
            if (!_onTheTableFoodSO.Contains(playerFoodSO))
            {
                _onTheTableFoodSO.Add(playerFoodSO);
            }
        }

        private void ShowFoodOnTheTable()
        {
            foreach (Food food in _tableFoodPrefabs)
            {
                if (food.ConnectedFoodSO == Player.PlayerCookingModule.FoodSO)
                {
                    food.gameObject.SetActive(true);
                }
            }
        }

        private void HideFoodOnTheTable(CookingRecipeSO cookingRecipeSO)
        {
            foreach (Food food in _tableFoodPrefabs)
            {
                foreach (var item in cookingRecipeSO.IngredientsForRecipe)
                {
                    if (food.ConnectedFoodSO == item)
                    {
                        food.gameObject.SetActive(false);
                        _onTheTableFoodSO.Remove(item);
                    }
                }
            }
        }

        private void CheckIfCanCook()
        {
            foreach (CookingRecipeSO cookingRecipeSO in DeliveryService.OrderedDishies)
            {
                if (CheckIfEqual(cookingRecipeSO.IngredientsForRecipe, _onTheTableFoodSO))
                {
                    CanBeCookedCookingRecipeSO?.Invoke(cookingRecipeSO);
                }
            }
        }

        private bool CheckIfEqual(List<FoodSO> ingredientsInRecipe, List<FoodSO> ingredientsOnTheTable)
        {
            bool isEqual = true;

            foreach (var element in ingredientsInRecipe)
            {
                if (!ingredientsOnTheTable.Contains(element))
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }
    }
}