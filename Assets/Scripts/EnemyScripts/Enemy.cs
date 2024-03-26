using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string PlayerDetected = nameof(PlayerDetected);

    [SerializeField] private Transform _points;

    private int _pointIndex;
    private float _minDistance = 0.2f;
    private float _runSpeed = 10f;
    private float _patrolSpeed = 3.5f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private List<Transform> _targetPoints = new List<Transform>();
    private Player _player;
    private Coroutine _patrolCoroutine;
    private Coroutine _chaseCoroutine;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        InitializeTargetPoints();
    }

    private void Start()
    {
        _player = Player.Instance;

        _player.EnteredTheForest += OnPlayerEnteredTheForest;
        _player.EnteredSafeZone += OnPlayerEnteredSafeZone;

        _patrolCoroutine = StartCoroutine(Patrolling());
    }

    private void OnPlayerEnteredSafeZone()
    {
        if(_chaseCoroutine != null)
        {
            StopCoroutine(_chaseCoroutine);
        }

        _patrolCoroutine = StartCoroutine(Patrolling());
    }

    private void OnDisable()
    {
        _player.EnteredTheForest -= OnPlayerEnteredTheForest;
        _player.EnteredSafeZone -= OnPlayerEnteredSafeZone;
    }

    private void OnPlayerEnteredTheForest()
    {
        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
        }

        _chaseCoroutine = StartCoroutine(Chasing());       
    }

    private void InitializeTargetPoints()
    {
        foreach (Transform child in _points)
        {
            _targetPoints.Add(child);
        }
    }

    private void MoveToNextPoint()
    {
        if (_targetPoints.Count == 0)
            return;

        _agent.speed = _patrolSpeed;
        _animator.SetBool(IsWalking, true);
        _agent.destination = _targetPoints[_pointIndex].position;
        _pointIndex = (_pointIndex + 1) % _targetPoints.Count;
    }

    private IEnumerator Patrolling()
    {
        MoveToNextPoint();

        while (enabled)
        {
            if (_agent.remainingDistance < _minDistance && !_agent.pathPending)
            {
                MoveToNextPoint();
            }

            yield return null;
        }
    }

    private void ChasePlayer()
    {
        _agent.speed = _runSpeed;
        _agent.destination = _player.transform.position;
        _animator.SetTrigger(PlayerDetected);
    }

    private IEnumerator Chasing()
    {
        while (enabled)
        {
            ChasePlayer();

            yield return null;
        }
    }
}
