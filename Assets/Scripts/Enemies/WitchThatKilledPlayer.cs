using UnityEngine;

namespace Enemies
{
    public class WitchThatKilledPlayer : MonoBehaviour
    {
        private float _eatSoundTimer = 3f;
        private bool _isEating;

       [SerializeField] private AudioSource _audioSource;

        private void FixedUpdate()
        {
            if (!_isEating)
            {
                _eatSoundTimer -= Time.deltaTime;

                if (_eatSoundTimer < 0)
                {
                    _audioSource.Play();
                    _isEating = true;
                }
            }
        }
    }
}
