using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemySoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _wolfRoar;
    [SerializeField] private AudioClip _howling;
    [SerializeField] private AudioClip _wolfDeath;
    [SerializeField] private AudioClip _cutTheWolf;

    private float _footStepTimer;
    private float _footStepTimerMax = 1.1f;

    private Enemy _enemy;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        _footStepTimer -= Time.deltaTime;

        if (_footStepTimer < 0)
        {
            _footStepTimer = _footStepTimerMax;

            if (_enemy.HasStepsSound)
            {
                PlayWolfStepSound();
            }
        }
    }

    public void PlayCutTheWolf()
    {
        _audioSource.clip = _cutTheWolf;
        _audioSource.Play();
    }

    public void PlayRoaring()
    {
        _audioSource.clip = _wolfRoar;
        _audioSource.Play();
    }

    public void PlayHowling()
    {
        _audioSource.clip = _howling;
        _audioSource.Play();
    }

    public void PlayWolfDeathScream()
    {
        _audioSource.clip = _wolfDeath;
        _audioSource.Play();
    }

    private void PlayWolfStepSound()
    {
        _audioSource.clip = _stepsSound;
        _audioSource.Play();
    }
}
