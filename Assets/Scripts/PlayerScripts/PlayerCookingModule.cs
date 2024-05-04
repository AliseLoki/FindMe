using UnityEngine;

public class PlayerCookingModule : MonoBehaviour
{
    private Player _player;

    private Food _food;
    private FoodSO _foodSO;
    private CookingRecipeSO _cookingRecipeSO;

    public Food Food => _food;

    public FoodSO FoodSO => _foodSO;

    public CookingRecipeSO CookingRecipeSO => _cookingRecipeSO;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void SetCookingRecipe(CookingRecipeSO cookingRecipeSO)
    {
       if (_cookingRecipeSO == null)
            _cookingRecipeSO = cookingRecipeSO;
    }

    public void ResetCookingRecipeSO()
    {
        _cookingRecipeSO = null;
    }

    public void SetCookingRecipeStateOfRedyness(StateOfReadyness readyness)
    {
        _cookingRecipeSO.Readyness = readyness;
    }

    public void SetFood(Food food, FoodSO foodSO)
    {
        _foodSO = foodSO;
        _food = food;
        _player.SetHasSomethingInHands(true);
    }

    public void GiveFood()
    {
        ResetFoodAndFoodSO();
    }

    public void ThrowFood()
    {
        if (_food != null)
        {
            Destroy(_food.gameObject);
        }

        ResetFoodAndFoodSO();
    }

    private void ResetFoodAndFoodSO()
    {
        _food = null;
        _foodSO = null;
        _cookingRecipeSO = null;
        _player.SetHasSomethingInHands(false);
    }
}
