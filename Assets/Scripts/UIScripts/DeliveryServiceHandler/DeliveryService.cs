using System;
using System.Collections.Generic;
using UnityEngine;
using Interactables;
using Interactables.Containers;

namespace DeliveryServiceHandler
{
    public class DeliveryService : MonoBehaviour
    {
        [SerializeField] private DeliveryServiceView _deliveryServiceView;
        [SerializeField] private RecievingOrdersPoint _recievingOrdersPoint;
        [SerializeField] private PackingPlace _packingPlace;
        [SerializeField] private TipsViewPanel _tipsViewPanel;

        private MenuSO _menuSO;

        private List<CookingRecipeSO> _orderedDishies = new List<CookingRecipeSO>();
        private List<CookingRecipeSO> _packedDishes = new List<CookingRecipeSO>();
        private List<StateOfReadyness> _packedDishesStates = new List<StateOfReadyness>();

        public event Action<string, List<CookingRecipeSO>> OrdersCanBeShown;
        public event Action<CookingRecipeSO> DishHasBeenPacked;
        public event Action<CookingRecipeSO> DishHasBeenDelivered;
        public event Action AllDishesHaveBeenDelivered;
        public event Action TimeToGoHasCome;

        public MenuSO MenuSO => _menuSO;

        public List<CookingRecipeSO> OrderedDishies => _orderedDishies;

        public List<CookingRecipeSO> PackedDishies => _packedDishes;

        public List<StateOfReadyness> PackedDishesStates => _packedDishesStates;

        private void OnEnable()
        {
            _recievingOrdersPoint.OrdersAreTaken += OnOrdersAreTaken;
            _packingPlace.CookingRecipeSOHasBeenPacked += OnCookingRecipeSOHasBeenPacked;
        }

        private void OnDisable()
        {
            _recievingOrdersPoint.OrdersAreTaken -= OnOrdersAreTaken;
            _packingPlace.CookingRecipeSOHasBeenPacked -= OnCookingRecipeSOHasBeenPacked;
        }

        public void GetLists(List<CookingRecipeSO> orderedDishies, List<CookingRecipeSO> packedDishies, List<StateOfReadyness> states)
        {
            _orderedDishies = orderedDishies;
            _packedDishes = packedDishies;
            _packedDishesStates = states;

            InitLists();
            SortSavedDishies();
            SetStateofReadyness();
        }

        public CookingRecipeSO CheckEquality(CookingRecipeSO cookingRecipeSO)
        {
            foreach (CookingRecipeSO cookingRecipeSOInPackage in _packedDishes)
            {
                if (cookingRecipeSOInPackage.RecipeName == cookingRecipeSO.RecipeName)
                {
                    return cookingRecipeSOInPackage;
                }
            }

            return null;
        }

        public void RemoveDeliveredDish(CookingRecipeSO cookingRecipeSO)
        {
            cookingRecipeSO.Readyness = StateOfReadyness.Uncooked;
            _packedDishes.Remove(cookingRecipeSO);
            _orderedDishies.Remove(cookingRecipeSO);
            DishHasBeenDelivered?.Invoke(cookingRecipeSO);
            CheckPackedDishesCount();
        }

        private void InitLists()
        {
            _deliveryServiceView.InitDishesFromSavedList(_orderedDishies);
        }

        private void CheckPackedDishesCount()
        {
            if (_packedDishes.Count == 0)
            {
                AllDishesHaveBeenDelivered?.Invoke();
            }
        }

        private void OnCookingRecipeSOHasBeenPacked(CookingRecipeSO cookingRecipeSO)
        {
            DishHasBeenPacked?.Invoke(cookingRecipeSO);
            _packedDishes.Add(cookingRecipeSO);
            _packedDishesStates.Add(cookingRecipeSO.Readyness);

            if (CheckIfOrdersAndPakcedDishesAreEqual())
            {
                _tipsViewPanel.ShowNoPlaceTip();
            }
        }

        private void SortSavedDishies()
        {
            foreach (CookingRecipeSO recipe in _orderedDishies)
            {
                if (CheckEquality(recipe))
                {
                    DishHasBeenPacked?.Invoke(recipe);
                }
            }
        }

        private bool CheckIfOrdersAndPakcedDishesAreEqual()
        {
            if (_packedDishes.Count == _orderedDishies.Count)
            {
                TimeToGoHasCome?.Invoke();
                return true;
            }

            return false;
        }

        private void OnOrdersAreTaken(string destinationPointName, MenuSO menuSO)
        {
            _menuSO = menuSO;

            if (_orderedDishies.Count < 1)
            {
                TakeOrders();
                OrdersCanBeShown?.Invoke(destinationPointName, _orderedDishies);
            }
        }

        private void TakeOrders()
        {
            for (int i = 0; i < _menuSO.MenuList.Count; i++)
            {
                CookingRecipeSO cookingRecipeSO = _menuSO.MenuList[i];
                _orderedDishies.Add(cookingRecipeSO);
            }
        }

        private void SetStateofReadyness()
        {
            for (int i = 0; i < _packedDishesStates.Count; i++)
            {
                for (int j = 0; j < _packedDishes.Count; j++)
                {
                    _packedDishes[j].Readyness = _packedDishesStates[i];
                    i++;
                }
            }
        }
    }
}
