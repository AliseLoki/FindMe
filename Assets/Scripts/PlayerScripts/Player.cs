using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Transform _handlePoint;

    [SerializeField] private bool _hasSomethingInHands;

    private Food _food;
    private FoodSO _foodSO;

    public Food FoodInHands => _food;
    public FoodSO FoodInHandsSO => _foodSO;

    public bool HasSomethingInHands => _hasSomethingInHands;

    public Transform HandlePoint => _handlePoint;

    private void Awake()
    {
        if (Instance != null)
        {
            print("јй€й€йй у нас двойник");
        }

        Instance = this;
    }

    public void SetHasSomethingInHands(bool hasSomethingInhands)
    {
        _hasSomethingInHands = hasSomethingInhands;
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
