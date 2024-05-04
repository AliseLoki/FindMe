using UnityEngine;

public class PlaceForWood : MonoBehaviour
{
    [SerializeField] private Transform _woodInOven;
    [SerializeField] private ParticleSystem _fireEffect;

     private SoundEffects _soundEffects;

    private void Awake()
    {
        _soundEffects = GameManager.Instance.GameEntryPoint.InitSoundEffects();
    }

    public void LightFire(bool isBurn)
    {
        _woodInOven.gameObject.SetActive(isBurn);
        _fireEffect.gameObject.SetActive(isBurn);

        if (isBurn == true)
        {
            _soundEffects.PlayBurningWoodSoundEffect(transform);
        }
    }
}
