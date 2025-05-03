using Interactables.Containers.Tables;
using PlayerController;
using SO;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DeliveryServiceHandler
{
    public class DeliveryServiceView : MonoBehaviour
    {
        [SerializeField] private Transform _recipesList;
        [SerializeField] private RecipeTemplateView _recipeTemplate;
        [SerializeField] private Transform _recipiesView;
        [SerializeField] private TMP_Text _destinationPointName;
        [SerializeField] private DeliveryService _deliveryService;
        [SerializeField] private CookingTable _cookingTable;
        [SerializeField] private Player _player;

        private bool _hasRecievedOrders;

        public event Action<CookingRecipeSO> DishPrepared;

        public string DestinationPointName => _destinationPointName.text;

        private void OnEnable()
        {
            _deliveryService.OrdersCanBeShown += ShowOrders;
            _deliveryService.DishHasBeenDelivered += OnDishHasBeenDelivered;
            _deliveryService.DishHasBeenPacked += OnDishHasBeenPacked;
            _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
            _cookingTable.CanBeCookedCookingRecipeSO += OnCanBeCookedCookingRecipeSO;
        }

        private void OnDisable()
        {
            _recipeTemplate.DishPrepared -= OnDishPrepared;
            _deliveryService.OrdersCanBeShown -= ShowOrders;
            _deliveryService.DishHasBeenPacked -= OnDishHasBeenPacked;
            _deliveryService.DishHasBeenDelivered -= OnDishHasBeenDelivered;
            _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
            _cookingTable.CanBeCookedCookingRecipeSO -= OnCanBeCookedCookingRecipeSO;
        }

        public void SetDestinationPointName(string villageName)
        {
            _destinationPointName.text = villageName.ToString();
        }

        public void InitDishesFromSavedList(List<CookingRecipeSO> dishesList)
        {
            if (dishesList.Count > 0)
            {
                _hasRecievedOrders = true;
            }

            foreach (var dish in dishesList)
            {
                var newTemplate = Instantiate(_recipeTemplate, _recipesList);
                newTemplate.InitLinks(_player);
                newTemplate.SetCookingRecipeSO(dish);
            }
        }

        private void OnDishHasBeenPacked(CookingRecipeSO cookingRecipeSO)
        {
            foreach (Transform recipe in _recipesList)
            {
                recipe.GetComponent<RecipeTemplateView>().SetHasBeenPacked(cookingRecipeSO);
            }
        }

        public void OnRecipeButtonPressed()
        {
            if (_hasRecievedOrders)
            {
                _recipiesView.gameObject.SetActive(_recipiesView.gameObject.activeSelf ? false : true);
            }
        }

        public void SetHasBeenCooked(CookingRecipeSO cookingRecipeSO)
        {
            foreach (Transform recipe in _recipesList)
            {
                recipe.GetComponent<RecipeTemplateView>().SetHasBeenCooked(cookingRecipeSO);
            }
        }

        private void OnAllDishesHaveBeenDelivered()
        {
            _hasRecievedOrders = false;
            _destinationPointName.text = string.Empty;
        }

        private void OnCanBeCookedCookingRecipeSO(CookingRecipeSO cookingRecipeSO)
        {
            foreach (Transform recipe in _recipesList)
            {
                RecipeTemplateView newRecipe = recipe.GetComponent<RecipeTemplateView>();
                newRecipe.SetCanCookButton(cookingRecipeSO, true);
                newRecipe.DishPrepared += OnDishPrepared;
            }
        }

        private void ShowOrders(string destinationPointName, List<CookingRecipeSO> ordersToShow)
        {
            if (!_hasRecievedOrders)
            {
                foreach (CookingRecipeSO cookingRecipeSO in ordersToShow)
                {
                    var newTemplate = Instantiate(_recipeTemplate, _recipesList);
                    newTemplate.InitLinks(_player);
                    newTemplate.SetCookingRecipeSO(cookingRecipeSO);
                }

                SetDestinationPointName(destinationPointName);
                _hasRecievedOrders = true;
            }
        }

        private void OnDishHasBeenDelivered(CookingRecipeSO cookingRecipeSO)
        {
            Transform recipeView = null;

            foreach (Transform recipe in _recipesList)
            {
                if (recipe.GetComponent<RecipeTemplateView>().CheckIfEqual(cookingRecipeSO))
                {
                    recipeView = recipe;
                }
            }

            if (recipeView != null)
            {
                Destroy(recipeView.gameObject);
            }
        }

        private void OnDishPrepared(CookingRecipeSO cookingRecipeSO)
        {
            foreach (Transform recipe in _recipesList)
            {
                recipe.GetComponent<RecipeTemplateView>().DeactivateButton();
            }

            DishPrepared?.Invoke(cookingRecipeSO);
        }
    }
}