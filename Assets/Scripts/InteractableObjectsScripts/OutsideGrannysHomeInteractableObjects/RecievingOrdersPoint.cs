using System;
using System.Collections.Generic;
using UnityEngine;
using Interactables.Containers;
using SettingsForYG;
using SO;

namespace Interactables
{
    public class RecievingOrdersPoint : InteractableObject
    {
        [SerializeField] private List<MenuSO> _allMenusSO;

        [SerializeField] private Container _barrelWithTomatoes;
        [SerializeField] private Container _basketWithCabbages;
        [SerializeField] private Container _bowlWithCheese;
        [SerializeField] private Container _meetHanger;

        [SerializeField] private LanguageSwitcher _languageSwitcher;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

        private int _woodCuterHomeIndex = 0;
        private int _firstVillageGrushevkaIndex = 1;
        private int _secondVillageYablonevkaIndex = 2;
        private int _thirdVillageKorovinoIndex = 3;
        private int _fourthVillageZelenovkaIndex = 4;
        private int _lastVillageZarechyeIndex = 5;

        private bool _orderIsTaken;

        private VillageNamesSO _villageNamesSO;

        public event Action<string, MenuSO> OrdersAreTaken;

        public bool OrderIsTaken => _orderIsTaken;

        private void OnEnable()
        {
            _languageSwitcher.VillageNamesGiven += InitVillageNamesSO;
            DeliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
            Player.PlayerCollisions.WolfHasBeenKilled += OnWolfHasBeenKilled;
        }

        private void OnDisable()
        {
            DeliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
            _languageSwitcher.VillageNamesGiven -= InitVillageNamesSO;
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
            int recievingOrdersSoundEffectIndex = 0;

            PlaySoundEffect(AudioClipsList[recievingOrdersSoundEffectIndex]);

            if (!_orderIsTaken)
            {
                ChooseMenuSO();
                _orderIsTaken = true;
            }
            else
            {
                TipsViewPanel.ShowFirstCompleteOldOrdersTip();
            }
        }

        private void OnWolfHasBeenKilled()
        {
            _meetHanger.gameObject.SetActive(true);
        }

        private void ChooseMenuSO()
        {
            if (_gameStatesSwitcher.IsEducationPlaying())
            {
                OrdersAreTaken?.Invoke(_villageNamesSO.Woodcutter, _allMenusSO[_woodCuterHomeIndex]);
            }
            else if (_gameStatesSwitcher.IsGamePlaying())
            {
                if (_meetHanger.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_villageNamesSO.LastVillageName, _allMenusSO[_lastVillageZarechyeIndex]);
                }
                else if (_bowlWithCheese.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_villageNamesSO.FourthVillageName, _allMenusSO[_fourthVillageZelenovkaIndex]);
                }
                else if (_basketWithCabbages.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_villageNamesSO.ThirdVillageName, _allMenusSO[_thirdVillageKorovinoIndex]);
                }
                else if (_barrelWithTomatoes.isActiveAndEnabled)
                {
                    OrdersAreTaken?.Invoke(_villageNamesSO.SecondVillageName, _allMenusSO[_secondVillageYablonevkaIndex]);
                }
                else
                {
                    OrdersAreTaken?.Invoke(_villageNamesSO.FirstVillageName, _allMenusSO[_firstVillageGrushevkaIndex]);
                }
            }
        }

        private void InitVillageNamesSO(VillageNamesSO villageNamesSO)
        {
            _villageNamesSO = villageNamesSO;
        }
    }
}
