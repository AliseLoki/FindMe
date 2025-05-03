using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSoundEffects : MonoBehaviour
    {
        [SerializeField] private AudioClip _getHurt;
        [SerializeField] private AudioClip _deathCry;
        [SerializeField] private AudioClip _takingWoodSoundEffect;
        [SerializeField] private AudioClip _takingGoldSoundEffect;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private AudioSource _audioSource;

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

        public void PlayTakingGoldSoundEffect()
        {
            PlaySoundEffect(_takingGoldSoundEffect);
        }

        public void PlaySoundEffect(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}