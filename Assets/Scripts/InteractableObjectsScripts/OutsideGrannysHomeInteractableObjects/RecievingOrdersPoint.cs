using System;
using System.Collections.Generic;
using UnityEngine;

public class RecievingOrdersPoint : InteractableObject
{
    [SerializeField] private List<MenuSO> _allMenusSO;

    [SerializeField] private Container _barrelWithTomatoes;
    [SerializeField] private Container _basketWithCabbages;
    [SerializeField] private Container _bowlWithCheese;
    [SerializeField] private Container _meetHanger;

    private int _woodCuterHomeIndex = 0;
    private int _firstVillageGrushevkaIndex = 1;
    private int _secondVillageYablonevkaIndex = 2;
    private int _thirdVillageKorovinoIndex = 3;
    private int _fourthVillageZelenovkaIndex = 4;
    private int _lastVillageZarechyeIndex = 5;

    private bool _orderIsTaken;

    private LanguageSwitcher _languageSwitcher;

    private VillageNamesSO _villageNamesSO;

    public event Action<string, MenuSO> OrdersAreTaken;

    private void OnEnable()
    {
        _languageSwitcher = GameManager.Instance.GameEntryPoint.InitLanguageSwitcher();
        _languageSwitcher.VillageNamesGiven += InitVillageNamesSO;
        DeliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }

    private void OnDisable()
    {
        DeliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
        _languageSwitcher.VillageNamesGiven -= InitVillageNamesSO;
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
            if (GameManager.Instance.IsEducationPlaying())
            {
                OrdersAreTaken?.Invoke(_villageNamesSO.Woodcutter, _allMenusSO[_woodCuterHomeIndex]);
            }
            else if (GameManager.Instance.IsGamePlaying())
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

            _orderIsTaken = true;
        }
        else
        {
            TipsViewPanel.ShowFirstCompleteOldOrdersTip();
        }
    }

    private void InitVillageNamesSO(VillageNamesSO villageNamesSO)
    {
        _villageNamesSO = villageNamesSO;
    }
}
