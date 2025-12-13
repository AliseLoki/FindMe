using System;
using PlayerController;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryServiceHandler
{
    public class RecipeTemplateView : MonoBehaviour
    {
        [SerializeField] private Image _dishImage;
        [SerializeField] private Image _cookedDishImage;
        [SerializeField] private Transform _ingredientsContainer;
        [SerializeField] private Transform _ingredient;
        [SerializeField] private Button _canCookButton;
        [SerializeField] private PlayerOld _player;

        private float _minUpPosition = 10;
        private bool _hasBeenCooked;
        private bool _hasBeenPacked;

        private CookingRecipeSO _cookingRecipeSO;

        public event Action<CookingRecipeSO> DishPrepared;

        public void InitLinks(PlayerOld player)
        {
            _player = player;
        }

        public void CookingRecipeSOHasBeenPacked(CookingRecipeSO cookingRecipeSO)
        {
            if (_cookingRecipeSO == cookingRecipeSO)
            {
                _hasBeenPacked = true;
            }
        }

        public void SetCookingRecipeSO(CookingRecipeSO cookingRecipeSO)
        {
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
            if (_cookingRecipeSO == cookingRecipeSO && !_hasBeenPacked)
            {
                _hasBeenCooked = false;
                _cookedDishImage.gameObject.SetActive(false);
            }
        }

        public void SetHasBeenPacked(CookingRecipeSO cookingRecipeSO)
        {
            if (CheckIfEqual(cookingRecipeSO))
            {
                _hasBeenPacked = true;
                _hasBeenCooked = true;
                DeactivateButton();
                _cookedDishImage.gameObject.SetActive(true);
            }
        }

        public void SetCanCookButton(CookingRecipeSO cookingRecipeSO, bool isActive)
        {
            if (CheckIfEqual(cookingRecipeSO) && !_hasBeenCooked && !_hasBeenPacked)
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
            if (_player.transform.position.y > _minUpPosition)
            {
                DishPrepared?.Invoke(_cookingRecipeSO);
                SetCanCookButton(_cookingRecipeSO, false);
                _cookedDishImage.gameObject.SetActive(true);
                _hasBeenCooked = true;
            }
        }

        public bool CheckIfEqual(CookingRecipeSO cookingRecipeSO)
        {
            if (_cookingRecipeSO == cookingRecipeSO)
            {
                return true;
            }

            return false;
        }
    }
}