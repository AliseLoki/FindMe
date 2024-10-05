using System.Collections.Generic;
using UnityEngine;

public class PlayerCookingModule : MonoBehaviour
{
    private Food _food;
    private FoodSO _foodSO;
    private CookingRecipeSO _cookingRecipeSO;

    [SerializeField] private Saver _saver;
    [SerializeField] private List<CookingRecipeSO> _allCookingRecipesSO;

    public Food Food => _food;

    public FoodSO FoodSO => _foodSO;

    public CookingRecipeSO CookingRecipeSO => _cookingRecipeSO;

    private void Start()
    {
        SetCookingRecipe(FindRecipeByName(_saver.LoadRecipeName()));
    }

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

    private CookingRecipeSO FindRecipeByName(string recipeName)
    {
        foreach (var item in _allCookingRecipesSO)
        {
            if(item.RecipeName == recipeName)
            {
                return item;
            }
        }

        return null;
    }
}
