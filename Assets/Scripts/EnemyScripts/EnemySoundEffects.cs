using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemySoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _wolfRoar;

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
                AudioSource.PlayClipAtPoint(_stepsSound, _enemy.transform.position);
            }
        }
    }

    public void Roar()
    {
        AudioSource.PlayClipAtPoint(_wolfRoar, _enemy.transform.position);
    }
}
