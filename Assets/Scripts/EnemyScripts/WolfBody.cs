using UnityEngine;

public class WolfBody : MonoBehaviour
{
    private TipsViewPanel _tipsViewPanel;

    [SerializeField] private ParticleSystem _meatEffect;

    private void Awake()
    {
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
    }

    private void OnMouseDown()
    {
        _meatEffect.Play();
        _tipsViewPanel.ShowYouHaveMeatNowTip();
    }
}
