using System;
using System.Collections.Generic;
using UnityEngine;

public class PackingPlace : GarbageContainer
{
    [SerializeField] private List<FoodSO> _canBePackedRecipeSO;
    [SerializeField] private Transform _package;

    private bool _isFull;

    public event Action<CookingRecipeSO> CookingRecipeSOHasBeenPacked;

    private void OnEnable()
    {
        DeliveryService.TimeToGoHasCome += OnTimeToGoHasCome;
        DeliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }

    private void OnDisable()
    {
        DeliveryService.TimeToGoHasCome -= OnTimeToGoHasCome;
        DeliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
    }

    private void OnAllDishesHaveBeenDelivered()
    {
        ShowPackage(true);
        _isFull = false;
    }

    private void ShowPackage(bool isShowed)
    {
        _package.gameObject.SetActive(isShowed);
    }

    protected override void UseObject()
    {
        int puttingFoodSoundEffectIndex = 0;

        if (_isFull)
        {
            PlaySoundEffect(AudioClipsList[puttingFoodSoundEffectIndex]);
            ShowPackage(false);
            Player.PlayerHands.ShowOrHideBackPack(true);
            return;
        }

        foreach (var foodSO in _canBePackedRecipeSO)
        {
            if (Player.PlayerCookingModule.FoodSO == foodSO)
            {
                PlaySoundEffect(AudioClipsList[puttingFoodSoundEffectIndex]);
                CookingRecipeSOHasBeenPacked?.Invoke(Player.PlayerCookingModule.CookingRecipeSO);
                Player.PlayerCookingModule.ThrowFood();
            }
        }
    }

    private void OnTimeToGoHasCome()
    {
        _isFull = true;
    }
}
