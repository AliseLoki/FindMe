using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private const string PlayerPrefsGoldAmount = nameof(PlayerPrefsGoldAmount);
    private const string PlayerPrefsHealthAmount = nameof(PlayerPrefsHealthAmount);

    [SerializeField] private AudioClip _takingGoldSoundEffect;

    private int _gold;
    private int _goldDefaultValue = 0;
    private int _health = 10;
    private int _maxhealth = 10;

    private Player _player;
    private TipsViewPanel _tipsViewPanel;

    public int Health => _health;

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
    public event Action WolfHasBeenKilled;

    public event Action WitchHasBeenAttacked;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    private void Start()
    {
        if (!GameManager.Instance.IsFirstStart)
        {
            _gold = PlayerPrefs.GetInt(PlayerPrefsGoldAmount, _goldDefaultValue);
            GoldAmountChanged?.Invoke(_gold);

            _health = PlayerPrefs.GetInt(PlayerPrefsHealthAmount, _maxhealth);
            HealthChanged?.Invoke(_health);
        }
        else if (GameManager.Instance.IsFirstStart)
        {
            _health = _maxhealth;
            HealthChanged?.Invoke(_health);
            _gold = _goldDefaultValue;
            GoldAmountChanged?.Invoke(_gold);
        }
    }

    public void OnWitchHasBeenAttacked()
    {
        WitchHasBeenAttacked?.Invoke(); 
    }

    public void OnWolfHasBeenKilled()
    {
        WolfHasBeenKilled?.Invoke();
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

    public void OnGoldAmountChanged(int gold)
    {
        _player.PlaySoundEffect(_takingGoldSoundEffect);
        _gold += gold;
        SaveGoldAmount(_gold);
    }

    public void OnHealthChanged(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxhealth);

        if (_health == 0)
        {
            PlayerHasDied?.Invoke();
        }
        else if (_health > 0)
        {
            SaveHealthAmount(_health);
        }

        HealthChanged?.Invoke(_health);
    }

    public bool CheckIfCanPay(int price)
    {
        if (_gold >= price)
        {
            _gold -= price;
            SaveGoldAmount(_gold);
            return true;
        }

        return false;
    }

    private void SaveHealthAmount(int health)
    {
        PlayerPrefs.SetInt(PlayerPrefsHealthAmount, health);
        PlayerPrefs.Save();
    }

    private void SaveGoldAmount(int gold)
    {
        PlayerPrefs.SetInt(PlayerPrefsGoldAmount, gold);
        PlayerPrefs.Save();
        GoldAmountChanged?.Invoke(gold);
    }
}
