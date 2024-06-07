using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsRunning = nameof(IsRunning);
    private const string IsAttacking = nameof(IsAttacking);
    private const string IsDying = nameof(IsDying);

    [SerializeField] private Transform _points;
    [SerializeField] private Player _player;
    [SerializeField] private WolfBody _wolfBody;

    [SerializeField] private EnemySoundEffects _enemySoundEffects;

    private int _pointIndex;
    private float _minDistance = 0.2f;
    private float _distanceToPlayer = 8f;
    private float _runSpeed = 10f;
    private float _patrolSpeed = 3.5f;

    private bool _isHowling;
    private bool _isAttacking;
    private bool _isDying;

    private NavMeshAgent _agent;
    private Animator _animator;
    private List<Transform> _targetPoints = new List<Transform>();

    private Coroutine _patrolCoroutine;
    private Coroutine _chaseCoroutine;

    public bool HasStepsSound { get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        InitializeTargetPoints();
    }

    private void Start()
    {
        _player.PlayerEventsHandler.EnteredTheForest += OnPlayerEnteredTheForest;
        _player.PlayerEventsHandler.EnteredSafeZone += OnPlayerEnteredSafeZone;
        _player.PlayerEventsHandler.EnteredGrannysHome += OnEnteredGrannysHome;
        _player.PlayerEventsHandler.EnteredVillage += OnEnteredVillage;
        _player.PlayerEventsHandler.WolfHasBeenKilled += OnWolfHasBeenKilled;

        _patrolCoroutine = StartCoroutine(Patrolling());
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredTheForest -= OnPlayerEnteredTheForest;
        _player.PlayerEventsHandler.EnteredSafeZone -= OnPlayerEnteredSafeZone;
        _player.PlayerEventsHandler.EnteredGrannysHome -= OnEnteredGrannysHome;
        _player.PlayerEventsHandler.EnteredVillage -= OnEnteredVillage;
        _player.PlayerEventsHandler.WolfHasBeenKilled -= OnWolfHasBeenKilled;
    }

    private void OnWolfHasBeenKilled()
    {
        _agent.isStopped = true;
        StopAllCoroutines();
        GetComponent<CapsuleCollider>().enabled = false;
        _wolfBody.gameObject.SetActive(true);
        HasStepsSound = false;

        if (!_isDying)
        {
            _animator.SetTrigger(IsDying);
            _isDying = true;
        }
    }

    private void InitializeTargetPoints()
    {
        foreach (Transform child in _points)
        {
            _targetPoints.Add(child);
        }
    }

    private void OnPlayerEnteredSafeZone()
    {
        if (!_isDying)
        {
            if (_patrolCoroutine != null)
            {
                return;
            }

            if (_chaseCoroutine != null)
            {
                _agent.isStopped = true;
                _isHowling = true;
                StopCoroutine(_chaseCoroutine);
                _chaseCoroutine = null;
            }

            _patrolCoroutine = StartCoroutine(Patrolling());
        }
    }

    private void OnPlayerEnteredTheForest()
    {
        if (!_isDying)
        {
            if (_chaseCoroutine != null)
            {
                return;
            }

            if (_patrolCoroutine != null)
            {
                StopCoroutine(_patrolCoroutine);
                _patrolCoroutine = null;
            }

            _chaseCoroutine = StartCoroutine(Chasing());
        }
    }

    private void OnEnteredGrannysHome()
    {
        OnPlayerEnteredSafeZone();
    }

    private void OnEnteredVillage()
    {
        OnPlayerEnteredSafeZone();
    }

    private void MoveToNextPoint()
    {
        SetNavMeshAgentParametres(0, _patrolSpeed, IsWalking);
        _agent.destination = _targetPoints[_pointIndex].position;
        _pointIndex = (_pointIndex + 1) % _targetPoints.Count;
    }

    private void ChasePlayer()
    {
        SetNavMeshAgentParametres(_distanceToPlayer, _runSpeed, IsRunning);
        _agent.destination = _player.transform.position;
        HasStepsSound = true;

        CheckDistanceToPlayer();
    }

    private bool CheckDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance <= _distanceToPlayer)
        {
            _isAttacking = true;
            return true;
        }

        return false;
    }

    private void SetNavMeshAgentParametres(float stoppingDistance, float speed, string currentAnimation)
    {
        _agent.stoppingDistance = stoppingDistance;
        _agent.isStopped = false;
        _agent.speed = speed;
        _animator.SetBool(currentAnimation, true);
    }

    private IEnumerator Patrolling()
    {
        yield return Waiting();
        MoveToNextPoint();

        while (enabled)
        {
            if (_agent.remainingDistance < _minDistance && !_agent.pathPending)
            {
                yield return Waiting();
                MoveToNextPoint();
            }

            yield return null;
        }
    }

    private IEnumerator Chasing()
    {
        while (enabled)
        {
            ChasePlayer();

            if (CheckDistanceToPlayer())
            {
                yield return Waiting();
            }

            yield return null;
        }
    }

    private IEnumerator Waiting()
    {
        HasStepsSound = false;

        if (!_isHowling && !_isAttacking)
        {
            _animator.SetBool(IsWalking, false);
        }
        else if (_isHowling)
        {
            _animator.SetBool(IsRunning, false);
            _enemySoundEffects.Roar();
            // _audioSource.Play();
        }
        else if (_isAttacking)
        {
            _animator.SetBool(IsAttacking, true);
            transform.LookAt(_player.transform);
        }

        float pause = 2.4f;
        yield return new WaitForSeconds(pause);

        if (CheckDistanceToPlayer() && _isAttacking)
        {
            _player.PlayerEventsHandler.OnHealthChanged(-1);
        }

        _isAttacking = false;
        _isHowling = false;

        _animator.SetBool(IsAttacking, false);
        // _audioSource.Stop();
        HasStepsSound = true;
    }
}
