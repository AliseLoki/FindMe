using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private int _speedBoostDuration = 5;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _boostSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 5f;

    [SerializeField] private PlayerAnimation _playerAnimation;

    private PlayerInventory _playerInventory;
    private NavMeshAgent _navMeshAgent;

    private bool _isWalking;
    private bool _isRunning;

    public bool IsWalking => _isWalking;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        _playerInventory.UsedSpeedBoost += OnUsedSpeedBoost;
    }

    private void OnDisable()
    {
        _playerInventory.UsedSpeedBoost -= OnUsedSpeedBoost;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            if (!_isRunning)
            {
                Rotate(Move(_moveSpeed));
            }
            else
            {
                Rotate(Move(_boostSpeed));
            }
        }
        else if (GameManager.Instance.IsGameFinished())
        {
            _playerAnimation.EnableIdle();
            _navMeshAgent.isStopped = true;
            _navMeshAgent.destination = transform.position;
        }
    }

    public void LookAtTheWitch(Witch witch)
    {
        _playerAnimation.EnableIdle();
        transform.LookAt(witch.transform.position);
    }

    public void Teleport(Transform transform)
    {
        _navMeshAgent.Warp(transform.position);
    }

    private void OnUsedSpeedBoost()
    {
        StartCoroutine(SpeedBoostCountdown());
    }

    private void Rotate(Vector3 movement)
    {
        transform.forward = Vector3.Slerp(transform.forward, movement, Time.deltaTime * _rotateSpeed);
    }

    private Vector3 Move(float moveSpeed)
    {
        float verticalInput = Input.GetAxis(Vertical);
        float horizontalInput = Input.GetAxis(Horizontal);

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _navMeshAgent.velocity = movement * moveSpeed;

        _isWalking = movement != Vector3.zero;

        return movement;
    }

    private IEnumerator SpeedBoostCountdown()
    {
        _isRunning = true;
        _playerAnimation.UseRunningAnimation(_isWalking);
        yield return new WaitForSeconds(_speedBoostDuration);
        _isRunning = false;
        _playerAnimation.UseRunningAnimation(false);
    }
}
