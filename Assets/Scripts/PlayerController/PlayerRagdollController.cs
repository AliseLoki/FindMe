using UnityEngine;

namespace PlayerController
{
    public class PlayerRagdollController : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _allPlayersParts;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            SwitchAllRigidbodys(true);
        }

        public void MakePhysical()
        {
            _animator.enabled = false;

            SwitchAllRigidbodys(false);
        }

        private void SwitchAllRigidbodys(bool isKinematic)
        {
            foreach (var part in _allPlayersParts)
            {
                part.isKinematic = isKinematic;
            }
        }
    }
}
