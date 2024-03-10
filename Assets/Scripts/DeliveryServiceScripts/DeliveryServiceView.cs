using UnityEngine;

public class DeliveryServiceView : MonoBehaviour
{
    [SerializeField] private Transform _recipeTemplate;
    [SerializeField] private Transform _recipesList;
    [SerializeField] private CookingTable _cookingTable;

    private void Awake()
    {
        _recipesList.gameObject.SetActive(false);
        ShowRecipes();
    }

    private void OnEnable()
    {
        _cookingTable.CanBeCooked += OnCanBeCooked;
    }

    private void OnDisable()
    {
        _cookingTable.CanBeCooked -= OnCanBeCooked;
    }

    public void ShowCustomersOrders()
    {
        if (_recipesList.gameObject.activeSelf)
        {
            _recipesList.gameObject.SetActive(false);
        }
        else
        {
            _recipesList.gameObject.SetActive(true);
            ShowRecipes();
        }
    }

    private void OnDishPrepared(CookingRecipeSO cookingRecipeSO)
    {
        _cookingTable.PrepareDish(cookingRecipeSO);

        foreach (Transform recipe in _recipesList)
        {
            recipe.GetComponent<RecipeTemplateView>().DeactivateButton();
        }
    }

    private void ShowRecipes()
    {
        int maxRecipeListCapacity = 7;

        foreach (CookingRecipeSO cookingRecipeSO in DeliveryService.Instance.GetOrderedDishiesList())
        {
            if (_recipesList.childCount < maxRecipeListCapacity)
            {
                var newTemplate = Instantiate(_recipeTemplate, _recipesList);
                newTemplate.GetComponent<RecipeTemplateView>().SetCookingRecipeSO(cookingRecipeSO);
            }
        }
    }

    private void OnCanBeCooked(CookingRecipeSO cookingRecipeSO)
    {
        foreach (Transform recipe in _recipesList)
        {
            recipe.GetComponent<RecipeTemplateView>().SetCanCookButton(cookingRecipeSO, true);
            recipe.GetComponent<RecipeTemplateView>().DishPrepared += OnDishPrepared;
        }
    }
}
