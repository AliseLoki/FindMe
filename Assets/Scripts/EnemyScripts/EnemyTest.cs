using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsRunning = nameof(IsRunning);
    private const string PlayerDetected = nameof(PlayerDetected);
    private const string PlayerCatched = nameof(PlayerCatched);

    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private int _pointIndex = 0;
    private Player _player;

    private void Awake()
    {
        _player = Player.Instance;
    }

    private void OnEnable()
    {
        Player.Instance.EnteredTheForest += OnPlayerEnteredTheForest;
    }

    private void Start()
    {

    }

    private void Update()
    {
        Patrol();
    }

    private void OnDisable()
    {
        Player.Instance.EnteredTheForest -= OnPlayerEnteredTheForest;
    }

    private void Patrol()
    {
        if (_pointIndex < _patrolPoints.Length)
        {
            _enemyAnimator.SetBool(IsWalking, true);
            _navMeshAgent.destination = _patrolPoints[_pointIndex].position;

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _pointIndex ++;
            }
        }
        else
        {
            _pointIndex = 0;
        }
    }

    private void OnPlayerEnteredTheForest()
    {

    }
}
