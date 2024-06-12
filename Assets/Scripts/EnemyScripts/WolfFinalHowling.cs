using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WolfFinalHowling : MonoBehaviour
{

    private float _howlTimer = 2;
    private float _maxHowlTimer = 4;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Howl();
    }

    private void Howl()
    {
        _howlTimer -= Time.deltaTime;

        if (_howlTimer < 0)
        {
            _howlTimer = _maxHowlTimer;
            _audioSource.Play();
        }
    }
}
