using UnityEngine;

namespace Enemies
{
    public class DieState : IState
    {
        private const string IsDying = nameof(IsDying);
        private Animator _animator;
        private Transform _pentagram;

        public DieState(EnemyStateMachine enemyStateMachine, Animator animator, Transform pentagram)
        {
            _animator = animator;
            _pentagram = pentagram;
        }

        public void Enter()
        {
            _pentagram.gameObject.SetActive(true);
            _animator.SetTrigger(IsDying);
        }
    }
}