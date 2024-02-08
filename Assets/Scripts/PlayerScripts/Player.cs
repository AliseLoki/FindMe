using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Transform _handlePoint;

    [SerializeField] private bool _hasSomethingInHands;

    private Food _food;

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

    public void SetFood(Food food)
    {
        _food = food;
    }

    public void ThrowFood()
    {
        Destroy(_food.gameObject);
        _hasSomethingInHands = false;
    }
}
