using System;
using PlayerController;
using SoundSystem;
using UnityEngine;

namespace Enemies
{
    public class Witch : MonoBehaviour
    {
        [SerializeField] private Transform _pentagram;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;

        private EnemyStateMachine _enemyStateMachine;
        private PlayerOld _player;
        private Music _music;

        public event Action WitchIsDead;

        private void Start()
        {
            _music.PlayWitchAppearMusic();
            _enemyStateMachine = new EnemyStateMachine();
            _enemyStateMachine.AddState(new MoveState(_enemyStateMachine, this.transform, _player));
            _enemyStateMachine.AddState(new AttackState(_enemyStateMachine, _player, _animator));
            _enemyStateMachine.AddState(new DieState(_enemyStateMachine, _animator, _pentagram));
            _enemyStateMachine.SetState<MoveState>();
        }

        private void Update()
        {
            _enemyStateMachine?.Update();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out PlayerOld player))
            {
                _enemyStateMachine.SetState<AttackState>();
            }
        }

        public void InitLinks(Music music, PlayerOld player)
        {
            _player = player;
            _music = music;
        }

        public void Die()
        {
            _enemyStateMachine.SetState<DieState>();
            WitchIsDead?.Invoke();
        }
    }
}