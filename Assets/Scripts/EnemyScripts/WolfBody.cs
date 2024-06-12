using UnityEngine;

public class WolfBody : MonoBehaviour
{
    private TipsViewPanel _tipsViewPanel;

    [SerializeField] private ParticleSystem _meatEffect;
    [SerializeField] private EnemySoundEffects _enemySoundEffects;

    private void Awake()
    {
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    private void OnMouseDown()
    {
        _enemySoundEffects.PlayCutTheWolf();
        _meatEffect.Play();
        _tipsViewPanel.ShowYouHaveMeatNowTip();
    }
}
