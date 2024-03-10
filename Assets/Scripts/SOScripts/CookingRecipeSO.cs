using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CookingRecipeSO : ScriptableObject
{
    public string RecipeName;
    public Sprite RecipeImage;
    public StateOfReadyness Readyness;
    public List<FoodSO> IngredientsForRecipe;
}
