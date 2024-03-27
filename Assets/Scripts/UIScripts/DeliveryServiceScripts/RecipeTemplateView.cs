using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeTemplateView : MonoBehaviour
{
    [SerializeField] private Image _dishImage;
    [SerializeField] private TMP_Text _recipeName;
    [SerializeField] private Transform _ingredientsContainer;
    [SerializeField] private Transform _ingredient;
    [SerializeField] private Button _canCookButton;

    private CookingRecipeSO _cookingRecipeSO;

    public CookingRecipeSO PreparedDish => _cookingRecipeSO;

    public event Action<CookingRecipeSO> DishPrepared;

    public void SetCookingRecipeSO(CookingRecipeSO cookingRecipeSO)
    {
        _recipeName.text = cookingRecipeSO.RecipeName;
        _dishImage.GetComponent<Image>().sprite = cookingRecipeSO.RecipeImage;
        _cookingRecipeSO = cookingRecipeSO;

        foreach (FoodSO foodSO in cookingRecipeSO.IngredientsForRecipe)
        {
            Transform newIngredient = Instantiate(_ingredient, _ingredientsContainer);
            newIngredient.GetComponent<Image>().sprite = foodSO.Sprite;
        }
    }

    public void SetCanCookButton(CookingRecipeSO cookingRecipeSO, bool active)
    {
        if (cookingRecipeSO.RecipeName == _recipeName.text)
        {
            _canCookButton.gameObject.SetActive(active);
        }
    }

    public void DeactivateButton()
    {
        _canCookButton.gameObject.SetActive(false);
    }

    public void OnDishPrepared()
    {
        DishPrepared?.Invoke(_cookingRecipeSO);
        this.gameObject.SetActive(false);
    }
}
