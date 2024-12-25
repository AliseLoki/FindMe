using UnityEngine;

namespace Enemies
{
    public class WolfBody : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _meatEffect;
        [SerializeField] private EnemySoundEffects _enemySoundEffects;
        [SerializeField] private TipsViewPanel _tipsViewPanel;

        private void OnMouseDown()
        {
            _enemySoundEffects.PlayCutTheWolf();
            _meatEffect.Play();
            _tipsViewPanel.ShowYouHaveMeatNowTip();
        }
    }
}
