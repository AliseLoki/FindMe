using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private int _gold;

    public event Action EnteredGrannysHome;
    public event Action ExitGrannysHome;

    public event Action EnteredTheForest;

    public event Action EnteredSafeZone;
    public event Action ExitSafeZone;

    public event Action EnteredVillage;
    public event Action ExitVillage;

    public event Action<int> GoldAmountChanged;

    public void OnEnteredGrannysHome()
    {
        EnteredGrannysHome?.Invoke();      
        TipsViewPanel.Instance.ShowYouAreSafeTip();
    }

    public void OnExitGrannysHome()
    {
        ExitGrannysHome?.Invoke();
        TipsViewPanel.Instance.ShowYouAreNotSafeTip();
    }

    public void OnEnteredTheForest()
    {
        EnteredTheForest?.Invoke();
        print("Зашла в Лес");
    }

    public void OnEnteredSafeZone()
    {
        EnteredSafeZone?.Invoke();
    }

    public void OnExitSafeZone()
    {
        ExitSafeZone?.Invoke();
        TipsViewPanel.Instance.ShowYouAreNotSafeTip();
    }

    public void OnEnteredVillage()
    {
        EnteredVillage?.Invoke();
    }

    public void OnExitVillage()
    {
        ExitVillage?.Invoke();
        TipsViewPanel.Instance.ShowYouAreNotSafeTip();
    }

    public void OnGoldAmountChanged()
    {
        _gold++;
        GoldAmountChanged?.Invoke(_gold);
        print("денюжки");
    }
}
