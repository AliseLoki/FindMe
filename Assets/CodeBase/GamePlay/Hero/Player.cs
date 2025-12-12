using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace Assets.CodeBase.GamePlay.Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private PlayerAnimator _animator;

        public void Init(IInput input, Configs configs)
        {
            _mover.Init(input, configs);
        }

        private void Update()
        {
            bool isMoving = _mover.Tick();
            _animator.SetWalkAnimation(isMoving);
        }
    }
}
