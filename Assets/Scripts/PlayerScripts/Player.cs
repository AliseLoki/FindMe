using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Transform _handlePoint;
    [SerializeField] private Transform _backpack;
    [SerializeField] private bool _hasSomethingInHands;

    private int _gold;
    private bool _hasBackPack;
    private bool _hasWood;
    private Food _food;
    private FoodSO _foodSO;
    private CookingRecipeSO _cookingRecipeSO;

    private List<CookingRecipeSO> _dishesForDeliver;

    public Food FoodInHands => _food;
    public FoodSO FoodInHandsSO => _foodSO;

    public CookingRecipeSO CookedRecipeSODish => _cookingRecipeSO;

    public bool HasSomethingInHands => _hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasWood => _hasWood;

    public Transform HandlePoint => _handlePoint;

    public event Action <int> GoldAmountChanged;
    public event Action EnteredTheForest;
    public event Action EnteredSafeZone;
    public event Action ExitSafeZone;

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

    public void OnEnteredSafeZone()
    {
        EnteredSafeZone?.Invoke();
        print("You are safe");
    }

    public void OnExitSafeZone()
    {
        ExitSafeZone?.Invoke();
    }

    public void OnEnteredTheForest()
    {
        EnteredTheForest?.Invoke();
        print("Зашла в Лес");
    }

    public void OnGoldAmountChanged()
    {
        _gold++;
        GoldAmountChanged?.Invoke(_gold);
        print("денюжки");
    }

    public CookingRecipeSO DeliverFood(CookingRecipeSO cookingRecipeSO)
    {
        foreach (var dish in _dishesForDeliver)
        {
            if (dish == cookingRecipeSO)
            {
                print(dish.RecipeName + "  " + dish.Readyness);
                _dishesForDeliver.Remove(dish);
                CheckIfDeliverIsComplited();
                return dish;
            }
        }

        return null;
    }

    public void SetHasWood(bool hasWood)
    {
        _hasWood = hasWood;
    }

    public void ShowOrHideBackPack(bool isActive)
    {
        _backpack.gameObject.SetActive(isActive);
        _hasBackPack = isActive;
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
        ResetFoodAndFoodSO();
    }

    public void ThrowFood()
    {
        Destroy(_food.gameObject);
        ResetFoodAndFoodSO();     
    }

    private void ResetFoodAndFoodSO()
    {
        _food = null;
        _foodSO = null;
        _hasSomethingInHands = false;
    }

    private void CheckIfDeliverIsComplited()
    {
        if(_dishesForDeliver.Count == 0)
        {
            ShowOrHideBackPack(false);
        }
    }
}
