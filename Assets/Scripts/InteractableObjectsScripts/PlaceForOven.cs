using UnityEngine;

public class PlaceForOven : MonoBehaviour
{
    [SerializeField] private Transform _woodInOven;
    [SerializeField] private ParticleSystem _fireEffect;


    public void LightFire(bool isBurn)
    {
        _woodInOven.gameObject.SetActive(isBurn);
        _fireEffect.gameObject.SetActive(isBurn);
    }
}
