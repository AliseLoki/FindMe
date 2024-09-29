using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PlayerSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _getHurt;
    [SerializeField] private AudioClip _deathCry;
    [SerializeField] private AudioClip _takingWoodSoundEffect;
    [SerializeField] private AudioClip _takingInventoryPrefabSoundEffect;
    [SerializeField] private AudioClip _takingGoldSoundEffect;

    [SerializeField] private ParticleSystem _hitEffect;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {
        PlaySoundEffect(_deathCry);
    }

    public void PlayHitEffects()
    {
        PlaySoundEffect(_getHurt);
        _hitEffect.Play();
    }


    public void PlayTakingWoodSoundEffect()
    {
        PlaySoundEffect(_takingWoodSoundEffect);
    }

    public void PlayTakingInventoryPrefabSoundEffect()
    {
        PlaySoundEffect(_takingInventoryPrefabSoundEffect);
    }

    public void PlayTakingGoldSoundEffect()
    {
        PlaySoundEffect(_takingGoldSoundEffect);
    }

    private void PlaySoundEffect(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
