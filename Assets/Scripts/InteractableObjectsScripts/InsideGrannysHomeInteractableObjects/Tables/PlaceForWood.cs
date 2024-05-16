using UnityEngine;

public class PlaceForWood : MonoBehaviour
{
    [SerializeField] private Transform _woodInOven;
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private AudioSource _audioSource;

    public void LightFire(bool isBurn)
    {
        _woodInOven.gameObject.SetActive(isBurn);
        _fireEffect.gameObject.SetActive(isBurn);

        if (isBurn == true)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
