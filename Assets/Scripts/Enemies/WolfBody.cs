using UnityEngine;

namespace Enemies
{
    public class WolfBody : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _meatEffect;
        [SerializeField] private EnemySoundEffects _enemySoundEffects;

        private void OnMouseDown()
        {
            _enemySoundEffects.PlayCutTheWolf();
            _meatEffect.Play();
        }
    }
}