using UnityEngine;

public class DeliveryServiceView : MonoBehaviour
{
    [SerializeField] private Transform _recipeTemplate;
    [SerializeField] private Transform _recipesList;
    [SerializeField] private CookingTable _cookingTable;
  
    private void Start()
    {
        _recipesList.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _cookingTable.CanBeCooked += OnCanBeCooked;
        _cookingTable.DishIsPrepared += OnDishIsPrepared;
    }

    private void OnDisable()
    {
        _cookingTable.CanBeCooked -= OnCanBeCooked;
        _cookingTable.DishIsPrepared -= OnDishIsPrepared;
    }

    public void ShowCustomersOrders()
    {
        if(_recipesList.gameObject.activeSelf)
        {
            _recipesList.gameObject.SetActive(false);
        }
        else
        {
            _recipesList.gameObject.SetActive(true);
            ShowRecipes();
        }
    }

   
    private void ShowRecipes()
    {
        foreach (CookingRecipeSO cookingRecipeSO in DeliveryService.Instance.GetOrderedDishiesList())
        {
           var newTemplate =  Instantiate(_recipeTemplate, _recipesList);
            newTemplate.GetComponent<RecipeTemplateView>().SetCookingRecipeSO(cookingRecipeSO);
        }
    }

    private void OnCanBeCooked(CookingRecipeSO cookingRecipeSO)
    {
        foreach (Transform  recipe in _recipesList)
        {
            recipe.GetComponent<RecipeTemplateView>().SetCanCookButton(cookingRecipeSO,true);
        }
    }

    private void OnDishIsPrepared(CookingRecipeSO cookingRecipeSO)
    {
        print("пр€чем готовые рецепты");
    }
}
