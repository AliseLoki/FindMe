using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemySoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _wolfRoar;

    private Enemy _enemy;
    private float _footStepTimer;
    private float _footStepTimerMax = 1.1f;

    private void Awake()
    {
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
