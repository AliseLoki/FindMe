using PlayerController;
using SoundSystem;
using System;
using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour
    {
        private const string IsAttacking = nameof(IsAttacking);
        private const string IsDying = nameof(IsDying);

        [SerializeField] private Transform _pentagram;
        [SerializeField] private AudioClip _witchDeathScream;
        [SerializeField] private AudioClip _witchSteps;

        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;

        private Player _player;
        private Music _music;

        private int _damage = -1;

        private float _timer;
        private float _timerDefaultValue = 1.5f;
        private float _moveSpeed = 0.5f;

        private bool _isAttacking;
        private bool _isDying;

        public event Action WitchIsDead;

        private void Awake()
        {
            _timer = _timerDefaultValue;
        }

        private void Start()
        {
            _music.PlayWitchAppearMusic();
        }

        private void Update()
        {
            if (!_isDying)
            {
                if (!_isAttacking)
                {
                    Move();
                }
                else
                {
                    _audioSource.Stop();
                    Attack();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                _animator.SetTrigger(IsAttacking);
                _isAttacking = true;
            }
        }

        public void InitLinks(Music music, Player player)
        {
            _player = player;
            _music = music;
        }

        public void Die()
        {
            _audioSource.loop = false;
            _audioSource.clip = _witchDeathScream;
            _audioSource.Play();
            _isDying = true;
            _pentagram.gameObject.SetActive(true);
            _animator.SetTrigger(IsDying);
            WitchIsDead?.Invoke();
        }

        private void Move()
        {
            transform.position += (_player.transform.position - transform.position).normalized * _moveSpeed * Time.deltaTime;
            transform.LookAt(_player.transform.position);
        }

        private void Attack()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _player.PlayerHealth.ChangeHealthValue(_damage);
                _timer = _timerDefaultValue;
            }
        }
    }
}