using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryServiceView : MonoBehaviour
{
    [SerializeField] private Transform _recipesList;
    [SerializeField] private RecipeTemplateView _recipeTemplate;

    private DeliveryService _deliveryService;
    private TestingTable _cookingTable;

    private bool _hasRecievedOrders;
    
    public event Action<CookingRecipeSO> DishPrepared;

    private void Awake()
    {
        _deliveryService = GameManager.Instance.GameEntryPoint.InitDeliveryService();
        _cookingTable = GameManager.Instance.GameEntryPoint.InitCookingTable();
    }

    private void OnEnable()
    {
        _deliveryService.OrdersCanBeShown += ShowOrders;
        _deliveryService.DishHasBeenDelivered += OnDishHasBeenDelivered;
        _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
        _cookingTable.CanBeCookedCookingRecipeSO += OnCanBeCookedCookingRecipeSO;
    }

    private void OnDisable()
    {
        _recipeTemplate.DishPrepared -= OnDishPrepared;
        _deliveryService.OrdersCanBeShown -= ShowOrders;
        _deliveryService.DishHasBeenDelivered -= OnDishHasBeenDelivered;
        _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
        _cookingTable.CanBeCookedCookingRecipeSO -= OnCanBeCookedCookingRecipeSO;
    }

    public void OnRecipeButtonPressed()
    {
        if (_hasRecievedOrders)
        {
            if (_recipesList.gameObject.activeSelf)
            {
                _recipesList.gameObject.SetActive(false);
            }
            else
            {
                _recipesList.gameObject.SetActive(true);
            }
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

    private void ShowOrders(List<CookingRecipeSO> ordersToShow)
    {
        if (!_hasRecievedOrders)
        {
            foreach (CookingRecipeSO cookingRecipeSO in ordersToShow)
            {
                var newTemplate = Instantiate(_recipeTemplate, _recipesList);
                newTemplate.SetCookingRecipeSO(cookingRecipeSO);
            }

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
