using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.GamePlay.Hero
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private IInput _input;
        private float _speed;
        private float _rotSpeed;
        private float _minStep;

        public void Init(IInput input, Configs configs)
        {
            _input = input;
            _speed = configs.Speed;
            _rotSpeed = configs.RotSpeed;
            _minStep = configs.MinStep;

            SetNavMeshAgentSettings(_agent);
        }

        public bool Tick()
        {
            Vector3 movement = GetInputVector(_input);
            ApplyMovementToAgent(movement, _agent, _speed);

            if (CheckIfMovementMoreThanMinStep(movement, _minStep))
            {
                Rotate(movement, _rotSpeed, transform);
                SetTransformPosition(_agent, transform);
                return true;
            }

            return false;
        }

        private void Rotate(Vector3 movement, float rotSpeed, Transform transform)
        {
            Quaternion targetRot = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        private bool CheckIfMovementMoreThanMinStep(Vector3 movement, float minStep) =>
            movement.sqrMagnitude > minStep;

        private void SetTransformPosition(NavMeshAgent agent, Transform transform) =>
            transform.position = agent.nextPosition;

        private void ApplyMovementToAgent(Vector3 movement, NavMeshAgent agent, float speed) =>
            agent.Move(speed * Time.deltaTime * movement);

        private Vector3 GetInputVector(IInput input) =>
            new Vector3(input.InputAxis.X, 0, input.InputAxis.Y).normalized;

        private void SetNavMeshAgentSettings(NavMeshAgent agent)
        {
            agent.updateRotation = false;
            agent.updatePosition = false;
        }
    }
}
