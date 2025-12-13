using PlayerController;
using UnityEngine;

namespace Enemies
{
    public class MoveState : IState
    {
        private const string IsAttacking = nameof(IsAttacking);

        private float _moveSpeed = 0.5f;
        private Transform _transform;
        private PlayerOld _player;

        public MoveState(EnemyStateMachine enemyStateMachine, Transform transform, PlayerOld player)
        {
            _transform = transform;
            _player = player;
        }

        public void Update()
        {
            _transform.position += (_player.transform.position - _transform.position).normalized * _moveSpeed * Time.deltaTime;
            _transform.LookAt(_player.transform.position);
        }
    }
}