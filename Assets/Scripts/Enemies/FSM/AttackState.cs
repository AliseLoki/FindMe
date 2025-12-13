using PlayerController;
using UnityEngine;

namespace Enemies
{
    public class AttackState : IState
    {
        private const string IsAttacking = nameof(IsAttacking);

        private int _damage = -1;
        private float _timer;
        private float _timerDefaultValue = 1.5f;
        private PlayerOld _player;
        private Animator _animator;

        public AttackState(EnemyStateMachine enemyStateMachine, PlayerOld player, Animator animator)
        {
            _player = player;
            _animator = animator;
        }

        public void Enter()
        {
            _animator.SetTrigger(IsAttacking);
            _timer = _timerDefaultValue;
        }

        public void Update()
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