using System.Collections.Generic;
using UnityEngine;
using Indexes;

namespace SO
{
    [CreateAssetMenu()]
    public class CookingRecipeSO : ScriptableObject
    {
        public string RecipeName;
        public Sprite RecipeImage;
        public StateOfReadyness Readyness;
        public List<FoodSO> IngredientsForRecipe;
    }
}
