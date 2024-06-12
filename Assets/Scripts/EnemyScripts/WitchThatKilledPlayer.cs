using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WitchThatKilledPlayer : MonoBehaviour
{
    private float _eatSoundTimer = 3f;
    private bool _isEating;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
