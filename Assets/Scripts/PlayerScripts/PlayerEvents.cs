using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private const string PlayerPrefsGoldAmount = nameof(PlayerPrefsGoldAmount);
    private const string PlayerPrefsHealthAmount = nameof(PlayerPrefsHealthAmount);

    [SerializeField] private Player _player;
    [SerializeField] private PlayerRagdollController _playerRagdollController;

    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    private int _gold;
    private int _goldDefaultValue = 0;
    private int _health = 10;
    private int _maxhealth = 10;

    private bool _isDead;

    public int Health => _health;

    public event Action EnteredGrannysHome;
    public event Action ExitGrannysHome;

    public event Action EnteredTheForest;

    public event Action EnteredSafeZone;
    public event Action ExitSafeZone;

    public event Action EnteredVillage;
    public event Action ExitVillage;

    public event Action EnteredPentagramZone;
    public event Action ExitPentagramZone;

    public event Action<int> GoldAmountChanged;
    public event Action<int> HealthChanged;

    public event Action PlayerHasDied;
    public event Action WolfHasBeenKilled;

    public event Action WitchHasBeenAttacked;

    private void Start()
    {
        if (!_gameStatesSwitcher.IsFirstStart)
        {
            _gold = PlayerPrefs.GetInt(PlayerPrefsGoldAmount, _goldDefaultValue);
            GoldAmountChanged?.Invoke(_gold);

            _health = PlayerPrefs.GetInt(PlayerPrefsHealthAmount, _maxhealth);
            HealthChanged?.Invoke(_health);
        }
        else if (_gameStatesSwitcher.IsFirstStart)
        {
            _health = _maxhealth;
            HealthChanged?.Invoke(_health);
            SaveHealthAmount(_health);
            _gold = _goldDefaultValue;
            GoldAmountChanged?.Invoke(_gold);
            SaveGoldAmount(_gold);
        }
    }

    public void OnWolfHasBeenKilled()
    {
        WolfHasBeenKilled?.Invoke();
    }

    public void OnWitchHasBeenAttacked()
    {
        WitchHasBeenAttacked?.Invoke();
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

    public void OnEnteredPentagramZone()
    {
        EnteredPentagramZone?.Invoke();
    }

    public void OnExitPentagramZone()
    {
        ExitPentagramZone?.Invoke();
    }

    public void OnGoldAmountChanged(int gold)
    {
        _player.PlayerSoundEffects.PlayTakingGoldSoundEffect();
        _gold += gold;
        SaveGoldAmount(_gold);
    }

    public void OnHealthChanged(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, _maxhealth);

        if (health < 0)
        {
            _player.PlayerSoundEffects.PlayHitEffects();
        }

        if (_health == 0 && !_isDead && !_gameStatesSwitcher.IsWitchAppeared())
        {
            _player.PlayerSoundEffects.PlayDeathSound();
            _player.PlayerAnimation.EnableDeathAnimation();
            _playerRagdollController.MakePhysical();
            PlayerHasDied?.Invoke();
            _isDead = true;
        }
        else if (_health == 0 && !_isDead && _gameStatesSwitcher.IsWitchAppeared())
        {
            _gameStatesSwitcher.WitchKilledPlayer();
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
    }

    private void SaveGoldAmount(int gold)
    {
        PlayerPrefs.SetInt(PlayerPrefsGoldAmount, gold);
        GoldAmountChanged?.Invoke(gold);
    }
}
