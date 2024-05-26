using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Witch : MonoBehaviour
{
    private const string IsAttacking = nameof(IsAttacking);
    private const string IsDying = nameof(IsDying);

    [SerializeField] private Transform _pentagram;

    private float _timer;
    private float _timerDefaultValue = 1.5f;
    private float _moveSpeed = 0.5f;

    private bool _isAttacking;
    private bool _isDying;

    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
        _timer = _timerDefaultValue;
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.WitchHasBeenAttacked += Die;
    }
    private void OnDisable()
    {
        _player.PlayerEventsHandler.WitchHasBeenAttacked -= Die;
    }

    private void Update()
    {
        if (!_isDying)
        {
            if (!_isAttacking)
            {
                Move();
            }
            else
            {
                Attack();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _animator.SetTrigger(IsAttacking);
            _isAttacking = true;
        }
    }

    private void Move()
    {
        transform.position += (_player.transform.position - transform.position).normalized * _moveSpeed * Time.deltaTime;
        transform.LookAt(_player.transform.position);
    }

    private void Attack()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _player.PlayerEventsHandler.OnHealthChanged(-1);
            _timer = _timerDefaultValue;
        }
    }

    private void Die()
    {
        _isDying = true;
        _pentagram.gameObject.SetActive(true);
        _animator.SetTrigger(IsDying);
    }
}
