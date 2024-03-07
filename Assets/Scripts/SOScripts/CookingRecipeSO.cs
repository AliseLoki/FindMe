using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CookingRecipeSO : ScriptableObject
{
    public Sprite RecipeImage;
    public string RecipeName;
    public List<FoodSO> IngredientsForRecipe;
}
