using PlayerController;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class WolfChaseState : WolvesBehaviour, IState
    {
        private const string IsRunning = nameof(IsRunning);
        private const string IsAttacking = nameof(IsAttacking);

        private float _timer;
        private float _timerDefaultValue = 2.5f;
        private float _distanceToPlayer = 8f;
        private float _runSpeed = 20f;

        private Transform _playerTransform;

        public WolfChaseState(NavMeshAgent agent, Animator animator, Transform playerTransform)
            : base(agent, animator)
        {
            _playerTransform = playerTransform;
        }

        public void Enter()
        {
            SetNavMeshAgentParametres(_distanceToPlayer, _runSpeed, IsRunning, false);
            _timer = _timerDefaultValue;
        }

        public void Update()
        {
            Agent.destination = _playerTransform.transform.position;
            Agent.transform.LookAt(_playerTransform.transform);

            if (Agent.remainingDistance < _distanceToPlayer)
            {
                _timer -= Time.deltaTime;
                Animator.SetTrigger(IsAttacking);

                if (_timer <= 0)
                {
                    // у синдикатов через геет компонент хэлс
                   // WARNING
                  //  _playerTransform.PlayerHealth.ChangeHealthValue(-1);
                    _timer = _timerDefaultValue;
                }
            }
            else
            {
                Animator.SetTrigger(IsRunning);
                _timer = _timerDefaultValue;
            }
        }

        public void Exit()
        {
            Agent.isStopped = true;
            Agent.destination = Agent.transform.position;
        }
    }
}