using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Transform _handlePoint;
    [SerializeField] private Transform _backpack;
    [SerializeField] private bool _hasSomethingInHands;

    private bool _hasBackPack;
    private Food _food;
    private FoodSO _foodSO;
    private CookingRecipeSO _cookingRecipeSO;

    private List<CookingRecipeSO> _dishesForDeliver;

    public Food FoodInHands => _food;
    public FoodSO FoodInHandsSO => _foodSO;

    public CookingRecipeSO CookedRecipeSODish => _cookingRecipeSO;

    public bool HasSomethingInHands => _hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public Transform HandlePoint => _handlePoint;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        _dishesForDeliver = new List<CookingRecipeSO>();
    }

    public CookingRecipeSO DeliverFood(CookingRecipeSO cookingRecipeSO)
    {
        foreach (var dish in _dishesForDeliver)
        {
            if (dish == cookingRecipeSO)
            {
                print(dish.RecipeName + "  " + dish.Readyness);
                _dishesForDeliver.Remove(dish);
                return dish;
            }
        }

        return null;
    }

    public void ShowBackPack()
    {
        _backpack.gameObject.SetActive(true);
        _hasBackPack = true;
    }

    public void SetDishesForDeliver(List<CookingRecipeSO> listFromPackingPlace)
    {
        _dishesForDeliver = listFromPackingPlace;

        foreach (var item in _dishesForDeliver)
        {
            print(item.RecipeName + " " + item.Readyness);
        }
    }

    public void SetHasSomethingInHands(bool hasSomethingInhands)
    {
        _hasSomethingInHands = hasSomethingInhands;
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
    }

    public void GiveFood()
    {
        _foodSO = null;
        _food = null;
        _hasSomethingInHands = false;
    }

    public void ThrowFood()
    {
        Destroy(_food.gameObject);
        _food = null;
        _foodSO = null;
        _hasSomethingInHands = false;
    }
}
