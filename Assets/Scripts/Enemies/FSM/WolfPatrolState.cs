using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class WolfPatrolState : WolvesBehaviour, IState
    {
        private const string IsWalking = nameof(IsWalking);

        private int _pointIndex = 0;
        private float _patrolSpeed = 3.5f;
        private float _minDistance = 0.2f;

        private List<Transform> _targetPoints = new List<Transform>();

        public WolfPatrolState(List<Transform> points, NavMeshAgent agent, Animator animator) : base(agent, animator)
        {
            _targetPoints = points;
        }

        public void Enter()
        {
            SetNavMeshAgentParametres(_minDistance, _patrolSpeed, IsWalking, false);
        }

        public void Update()
        {
            if (Agent.remainingDistance < _minDistance && !Agent.pathPending)
            {
                Move();
            }
        }

        public void Exit()
        {
            Agent.isStopped = true;
        }

        private void Move()
        {
            Agent.destination = _targetPoints[_pointIndex].position;
            _pointIndex = (_pointIndex + 1) % _targetPoints.Count;
        }
    }
}