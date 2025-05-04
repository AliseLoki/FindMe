using GameControllers;
using Indexies;
using Interactables.Containers;
using MainCanvas;
using SettingsForYG;
using SO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class RecievingOrdersPoint : InteractableObject
    {
        [SerializeField] private List<MenuSO> _allMenusSO;
        [SerializeField] private Container _barrelWithTomatoes;
        [SerializeField] private Container _basketWithCabbages;
        [SerializeField] private Container _bowlWithCheese;
        [SerializeField] private Container _meetHanger;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private CanvasUI _canvasUI;

        private bool _orderIsTaken;

        private Dictionary<NamesOfVillages, string> _namesOfVillages;

        public event Action<string, MenuSO> OrdersAreTaken;

        public bool OrderIsTaken => _orderIsTaken;

        private void OnEnable()
        {
            _canvasUI.LanguageSetter.LanguageInitialized += OnLanguageInitialized;
            DeliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
            Player.PlayerCollisions.WolfHasBeenKilled += OnWolfHasBeenKilled;
        }
        private void OnDisable()
        {
            _canvasUI.LanguageSetter.LanguageInitialized -= OnLanguageInitialized;
            DeliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
            Player.PlayerCollisions.WolfHasBeenKilled -= OnWolfHasBeenKilled;
        }

        public void GetOrderIsTaken(bool isTaken)
        {
            _orderIsTaken = isTaken;
        }

        public void OnAllDishesHaveBeenDelivered()
        {
            _orderIsTaken = false;
        }

        protected override void UseObject()
        {
            Player.PlayerSoundEffects.PlaySoundEffect(Clip);

            if (!_orderIsTaken)
            {
                ChooseMenuSO();
                _orderIsTaken = true;
            }
        }

        private void OnLanguageInitialized(AllPhrases text)
        {
            _namesOfVillages = text.VillagesNames;
        }

        private void OnWolfHasBeenKilled()
        {
            _meetHanger.gameObject.SetActive(true);
        }

        private void ChooseMenuSO()
        {
            if (_gameStatesSwitcher.IsEducationPlaying())
            {
                OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.Woodcutter], _allMenusSO[(int)NamesOfVillages.Woodcutter]);
            }
            else if (_gameStatesSwitcher.IsGamePlaying())
            {
                if (_meetHanger.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.LastVillageName], _allMenusSO[(int)NamesOfVillages.LastVillageName]);
                }
                else if (_bowlWithCheese.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.FourthVillageName], _allMenusSO[(int)NamesOfVillages.FourthVillageName]);
                }
                else if (_basketWithCabbages.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.ThirdVillageName], _allMenusSO[(int)NamesOfVillages.ThirdVillageName]);
                }
                else if (_barrelWithTomatoes.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.SecondVillageName], _allMenusSO[(int)NamesOfVillages.SecondVillageName]);
                }
                else
                {
                    OrdersAreTaken?.Invoke(_namesOfVillages[NamesOfVillages.FirstVillageName], _allMenusSO[(int)NamesOfVillages.FirstVillageName]);
                }
            }
        }
    }
}