using Indexies;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu]
    public class CookingRecipeSO : ScriptableObject
    {
        public string RecipeName;
        public Sprite RecipeImage;
        public StateOfReadyness Readyness;
        public List<FoodSO> IngredientsForRecipe;
    }
}