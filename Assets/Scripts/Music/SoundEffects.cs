using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private SoundEffectSO _soundEffectsSO;
    
    public void PlayPuttingFoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.PuttingFood, transform.position);
    }

    public void PlayGettingFoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.GettingFood, transform.position);
    }

    public void PlayCookingFoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.CookingFood, transform.position);
    }

    public void PlayCuttingFoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.CuttingFood, transform.position);
    }

    public void PlayBurningWoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.BurningFire, transform.position);
    }

    public void PlayThwrowingFoodSoundEffect(Transform transform)
    {
        PlaySoundEffect(_soundEffectsSO.ThrowingFood, transform.position);
    }

    private void PlaySoundEffect(AudioClip audioClip, Vector3 position, float volume = 10f)
    {
       AudioSource.PlayClipAtPoint(audioClip, position, volume);      
    }
}
