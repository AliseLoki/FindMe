using System.Collections.Generic;
using Assets.CodeBase.GamePlay.Hero;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject _wolfBody;
        [SerializeField] private Collider _collider;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        private List<Transform> _targetPoints = new();

        private EnemyStateMachine _wolfStateMachine;

        public void Init(Transform points, Transform player)
        {
            _wolfStateMachine = new EnemyStateMachine();

            _wolfStateMachine.AddState(new WolfPatrolState(_targetPoints, _agent, _animator));
            _wolfStateMachine.AddState(new WolfChaseState(_agent, _animator, player));
            _wolfStateMachine.AddState(new WolfStopState(_wolfStateMachine, _agent, _animator));
            _wolfStateMachine.AddState(new WolfDieState(_agent, _animator, _collider, _wolfBody));


            InitializeTargetPoints(points);
            _wolfStateMachine.SetState<WolfPatrolState>();
            //_player.PlayerCollisions.EnteredTheForest += OnPlayerEnteredTheForest;
            //_player.PlayerCollisions.EnteredSafeZone += OnPlayerEnteredSafeZone;
            //_player.PlayerCollisions.WolfHasBeenKilled += OnWolfHasBeenKilled;
        }

        private void OnDisable()
        {
            //_player.PlayerCollisions.EnteredTheForest -= OnPlayerEnteredTheForest;
            //_player.PlayerCollisions.EnteredSafeZone -= OnPlayerEnteredSafeZone;
            //_player.PlayerCollisions.WolfHasBeenKilled -= OnWolfHasBeenKilled;
        }

        private void Update()
        {
            _wolfStateMachine?.Update();
        }

        private void InitializeTargetPoints(Transform points)
        {
            foreach (Transform child in points)
            {
                _targetPoints.Add(child);
            }
        }

        private void OnWolfHasBeenKilled()
        {
            _wolfStateMachine.SetState<WolfDieState>();
        }

        public void OnPlayerEnteredSafeZone()
        {
            _wolfStateMachine.SetState<WolfStopState>();
        }

        public void OnPlayerEnteredTheForest()
        {
            _wolfStateMachine.SetState<WolfChaseState>();
        }
    }
}