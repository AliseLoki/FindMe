using UnityEngine;

namespace Assets.CodeBase.GamePlay.Hero
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string IsWalking = nameof(IsWalking);

        [SerializeField] private Animator _animator;

        public void SetWalkAnimation(bool isWalking)
        {
            _animator.SetBool(IsWalking, isWalking);
        }
    }
}
