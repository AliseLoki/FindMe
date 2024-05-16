using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] private AudioClip _takingGoldSoundEffect;

    private int _gold = 10;
    private int _health = 0;
    private int _maxhealth = 10;

    private Player _player;
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
        _player = GetComponent<Player>();
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    private void Start()
    {
        OnHealthChanged(_maxhealth);
        GoldAmountChanged(_gold);
    }

    public void OnEnteredGrannysHome()
    {
        EnteredGrannysHome?.Invoke();
        _tipsViewPanel.gameObject.SetActive(true);
        _tipsViewPanel.ShowYouAreSafeTip();
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
        _player.PlaySoundEffect(_takingGoldSoundEffect);
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

    public bool CheckIfCanPay(int price)
    {
        if (_gold >= price)
        {
            _gold -= price;
            GoldAmountChanged?.Invoke(_gold);
            return true;
        }

        return false;
    }
}
