using PlayerController;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _points;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _wolfBody;
        [SerializeField] private Collider _collider;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        private List<Transform> _targetPoints = new List<Transform>();

        private EnemyStateMachine _wolfStateMachine;

        private void Awake()
        {
            InitializeTargetPoints();
        }

        private void Start()
        {
            _wolfStateMachine = new EnemyStateMachine();
            _wolfStateMachine.AddState(new WolfPatrolState(_targetPoints, _agent, _animator));
            _wolfStateMachine.AddState(new WolfChaseState(_agent, _animator, _player));
            _wolfStateMachine.AddState(new WolfStopState(_wolfStateMachine, _agent, _animator));
            _wolfStateMachine.AddState(new WolfDieState(_agent, _animator, _collider, _wolfBody));

            _wolfStateMachine.SetState<WolfPatrolState>();

            _player.PlayerCollisions.EnteredTheForest += OnPlayerEnteredTheForest;
            _player.PlayerCollisions.EnteredSafeZone += OnPlayerEnteredSafeZone;
            _player.PlayerCollisions.WolfHasBeenKilled += OnWolfHasBeenKilled;
        }

        private void OnDisable()
        {
            _player.PlayerCollisions.EnteredTheForest -= OnPlayerEnteredTheForest;
            _player.PlayerCollisions.EnteredSafeZone -= OnPlayerEnteredSafeZone;
            _player.PlayerCollisions.WolfHasBeenKilled -= OnWolfHasBeenKilled;
        }

        private void Update()
        {
            _wolfStateMachine?.Update();
        }

        private void InitializeTargetPoints()
        {
            foreach (Transform child in _points)
            {
                _targetPoints.Add(child);
            }
        }

        private void OnWolfHasBeenKilled()
        {
            _wolfStateMachine.SetState<WolfDieState>();
        }

        private void OnPlayerEnteredSafeZone()
        {
            _wolfStateMachine.SetState<WolfStopState>();
        }

        private void OnPlayerEnteredTheForest()
        {
            _wolfStateMachine.SetState<WolfChaseState>();
        }
    }
}