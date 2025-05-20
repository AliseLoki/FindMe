using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class WolfStopState : WolvesBehaviour, IState
    {
        private const string HasStopped = nameof(HasStopped);

        private float _timer;
        private float _timerDefaultValue = 5f;
        private EnemyStateMachine _wolfStateMachine;

        public WolfStopState(EnemyStateMachine enemyStateMachine, NavMeshAgent agent, Animator animator)
            : base(agent, animator)
        {
            _wolfStateMachine = enemyStateMachine;
        }

        public void Enter()
        {
            Animator.SetTrigger(HasStopped);
            _timer = _timerDefaultValue;
        }

        public void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _wolfStateMachine.SetState<WolfPatrolState>();
            }
        }
    }
}