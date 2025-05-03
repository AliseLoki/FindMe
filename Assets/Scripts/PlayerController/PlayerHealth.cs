using GameControllers;
using System;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Player))]
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

        private int _health = 10;
        private int _maxhealth = 10;

        private bool _isDead;

        public event Action<int> HealthChanged;

        public event Action PlayerHasDied;

        public int Health => _health;

        private void Awake()
        {
            if (_gameStatesSwitcher.IsFirstStart)
            {
                HealthChanged?.Invoke(_health);
            }
        }

        public void InitHealth(int health)
        {
            _health = health;
            HealthChanged?.Invoke(_health);
        }

        public void ChangeHealthValue(int healthChangeValue)
        {
            _health = Mathf.Clamp(_health + healthChangeValue, 0, _maxhealth);

            if (healthChangeValue < 0)
            {
                _player.PlayerSoundEffects.PlayHitEffects();
            }

            if (_health == 0 && !_isDead && !_gameStatesSwitcher.IsWitchAppeared())
            {
                _player.PlayerSoundEffects.PlayDeathSound();
                _player.PlayerAnimation.EnableDeathAnimation();
                _player.PlayerRagdollController.MakePhysical();
                PlayerHasDied?.Invoke();
                _isDead = true;
            }
            else if (_health == 0 && !_isDead && _gameStatesSwitcher.IsWitchAppeared())
            {
                _gameStatesSwitcher.WitchKilledPlayer();
            }

            HealthChanged?.Invoke(_health);
        }
    }
}