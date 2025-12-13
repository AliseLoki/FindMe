using System.Collections;
using Enemies;
using GameControllers;
using UnityEngine;
using UnityEngine.AI;
using Villages;

namespace PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        [SerializeField] private int _speedBoostDuration = 5;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _boostSpeed = 10f;
        [SerializeField] private float _rotateSpeed = 5f;
        [SerializeField] private PlayerOld _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private LastVillage _lastVillage;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private bool _isWalking;
        private bool _isRunning;

        public bool IsWalking => _isWalking;

        private void OnEnable()
        {
            _navMeshAgent.updateRotation = false;
            _player.PlayerInventory.UsedSpeedBoost += OnUsedSpeedBoost;
            _lastVillage.WitchAppeared += LookAtTheWitch;
        }

        private void OnDisable()
        {
            _player.PlayerInventory.UsedSpeedBoost -= OnUsedSpeedBoost;
            _lastVillage.WitchAppeared -= LookAtTheWitch;
        }

        private void Update()
        {
            if (_gameStatesSwitcher.IsGamePlaying())
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
            else if (_gameStatesSwitcher.IsGameFinished())
            {
                StopMoving();
            }
        }

        public void LookAtTheWitch(Witch witch)
        {
            _player.PlayerAnimation.EnableIdle();
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
            _player.PlayerAnimation.UseRunningAnimation(_isWalking);
            yield return new WaitForSeconds(_speedBoostDuration);
            _isRunning = false;
            _player.PlayerAnimation.UseRunningAnimation(false);
        }

        private void StopMoving()
        {
            _player.PlayerAnimation.EnableIdle();
            _navMeshAgent.isStopped = true;
            _navMeshAgent.destination = transform.position;
        }
    }
}