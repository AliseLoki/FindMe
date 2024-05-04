using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private int _gold = 0;
    private int _health = 10;
    private int _maxhealth = 10;

    private TipsViewPanel _tipsViewPanel;

    public event Action EnteredGrannysHome;
    public event Action ExitGrannysHome;

    public event Action EnteredTheForest;

    public event Action EnteredSafeZone;
    public event Action ExitSafeZone;

    public event Action EnteredVillage;
    public event Action ExitVillage;

    public event Action<int> GoldAmountChanged;
    public event Action<int> HealthChanged;

    public event Action PlayerHasDied;

    private void Awake()
    {
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    public void OnEnteredGrannysHome()
    {
        EnteredGrannysHome?.Invoke();

        if (GameManager.Instance.IsEducationPlaying())
        {
            _tipsViewPanel.ShowYouAreSafeTip();
        }
    }

    public void OnExitGrannysHome()
    {
        ExitGrannysHome?.Invoke();
        _tipsViewPanel.ShowYouAreNotSafeTip();
    }

    public void OnEnteredTheForest()
    {
        EnteredTheForest?.Invoke();
    }

    public void OnEnteredSafeZone()
    {
        EnteredSafeZone?.Invoke();
    }

    public void OnExitSafeZone()
    {
        ExitSafeZone?.Invoke();
        _tipsViewPanel.ShowYouAreNotSafeTip();
    }

    public void OnEnteredVillage()
    {
        EnteredVillage?.Invoke();
    }

    public void OnExitVillage()
    {
        ExitVillage?.Invoke();
        _tipsViewPanel.ShowYouAreNotSafeTip();
    }

    public void OnGoldAmountChanged()
    {
        _gold++;
        GoldAmountChanged?.Invoke(_gold);
    }

    public void OnHealthChanged(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxhealth);
        HealthChanged?.Invoke(_health);

        if (_health == 0)
        {
            PlayerHasDied?.Invoke();
        }
    }
}
