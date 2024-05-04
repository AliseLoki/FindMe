using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeTemplateView : MonoBehaviour
{
    [SerializeField] private Image _dishImage;
    [SerializeField] private Image _cookedDishImage;
    [SerializeField] private TMP_Text _recipeName;
    [SerializeField] private Transform _ingredientsContainer;
    [SerializeField] private Transform _ingredient;
    [SerializeField] private Button _canCookButton;

    private bool _hasBeenCooked;

    private CookingRecipeSO _cookingRecipeSO;

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

    public void SetHasBeenCooked(CookingRecipeSO cookingRecipeSO)
    {
        if (_cookingRecipeSO = cookingRecipeSO)
        {
            _hasBeenCooked = false;
        }
    }

    public void SetCanCookButton(CookingRecipeSO cookingRecipeSO, bool isActive)
    {
        if (CheckIfEqual(cookingRecipeSO) && !_hasBeenCooked)
        {
            _canCookButton.gameObject.SetActive(isActive);
        }
    }

    public void DeactivateButton()
    {
        _canCookButton.gameObject.SetActive(false);
    }

    public void OnCanCookButtonPressed()
    {
        DishPrepared?.Invoke(_cookingRecipeSO);
        SetCanCookButton(_cookingRecipeSO, false);
        _cookedDishImage.gameObject.SetActive(true);
        _hasBeenCooked = true;
    }

    public bool CheckIfEqual(CookingRecipeSO cookingRecipeSO)
    {
        if (cookingRecipeSO.RecipeName == _recipeName.text)
        {
           return true;
        }

        return false;
    }
}
