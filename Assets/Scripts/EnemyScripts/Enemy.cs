using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsRunning = nameof(IsRunning);
    private const string PlayerDetected = nameof(PlayerDetected);

    [SerializeField] private Transform _points;
    [SerializeField] private EnemySoundEffects _enemySoundEffects;
    [SerializeField] private Player _player;

    private int _pointIndex;
    private float _minDistance = 0.2f;
    private float _distanceToPlayer = 8f;
    private float _runSpeed = 10f;
    private float _patrolSpeed = 3.5f;

    private bool _isHowling;

    // private AudioSource _audioSource;
    private NavMeshAgent _agent;
    private Animator _animator;
    private List<Transform> _targetPoints = new List<Transform>();

    private Coroutine _patrolCoroutine;
    private Coroutine _chaseCoroutine;

    public bool HasStepsSound { get; private set; }

    private void Awake()
    {
        // _audioSource = GetComponent<AudioSource>();
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

        _patrolCoroutine = StartCoroutine(Patrolling());
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredTheForest -= OnPlayerEnteredTheForest;
        _player.PlayerEventsHandler.EnteredSafeZone -= OnPlayerEnteredSafeZone;
        _player.PlayerEventsHandler.EnteredGrannysHome -= OnEnteredGrannysHome;
        _player.PlayerEventsHandler.EnteredVillage -= OnEnteredVillage;
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
        if (_chaseCoroutine != null)
        {
            _agent.isStopped = true;
            _isHowling = true;
            StopCoroutine(_chaseCoroutine);
        }

        _patrolCoroutine = StartCoroutine(Patrolling());
    }

    private void OnPlayerEnteredTheForest()
    {
        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
        }

        _chaseCoroutine = StartCoroutine(Chasing());
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

            yield return null;
        }
    }

    private IEnumerator Waiting()
    {
        HasStepsSound = false;

        if (!_isHowling)
        {
            _animator.SetBool(IsWalking, false);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
            _enemySoundEffects.Roar();
            // _audioSource.Play();

        }

        float pause = 2.4f;
        yield return new WaitForSeconds(pause);
        _isHowling = false;
        // _audioSource.Stop();
        HasStepsSound = true;
    }
}
