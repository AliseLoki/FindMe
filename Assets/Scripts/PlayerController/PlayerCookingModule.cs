using Indexies;
using Interactables;
using SO;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Player))]
    public class PlayerCookingModule : MonoBehaviour
    {
        private Food _food;
        private FoodSO _foodSO;
        private CookingRecipeSO _cookingRecipeSO;

        [SerializeField] private List<CookingRecipeSO> _allCookingRecipesSO;

        public Food Food => _food;

        public FoodSO FoodSO => _foodSO;

        public CookingRecipeSO CookingRecipeSO => _cookingRecipeSO;

        public void SetCookingRecipe(CookingRecipeSO cookingRecipeSO)
        {
            if (_cookingRecipeSO == null)
                _cookingRecipeSO = cookingRecipeSO;
        }

        public void SetCookingRecipeStateOfRedyness(StateOfReadyness readyness)
        {
            _cookingRecipeSO.Readyness = readyness;
        }

        public void SetFood(Food food, FoodSO foodSO)
        {
            _foodSO = foodSO;
            _food = food;
        }

        public void GiveFood()
        {
            _food = null;
            _foodSO = null;
            _cookingRecipeSO = null;
        }

        public CookingRecipeSO FindRecipeByName(string recipeName)
        {
            foreach (var item in _allCookingRecipesSO)
            {
                if (item.RecipeName == recipeName)
                {
                    return item;
                }
            }

            return null;
        }
    }
}