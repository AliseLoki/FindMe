using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostView : MonoBehaviour
{
    [SerializeField] private Image _speedBoostImage;

    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _speedBoostImage.fillAmount = 1;
        _playerInventory = GameManager.Instance.GameEntryPoint.InitPlayer().PlayerInventory;
    }

    private void OnEnable()
    {
        _playerInventory.UsedSpeedBoost += OnUsedSpeedBoost;
    }

    private void OnDisable()
    {
        _playerInventory.UsedSpeedBoost -= OnUsedSpeedBoost;
    }

    private void OnUsedSpeedBoost()
    {
        _speedBoostImage.gameObject.SetActive(true);
        StartCoroutine(SpeedBoostCountDownRoutine());
    }

    private IEnumerator SpeedBoostCountDownRoutine()
    {
        int duration = 5;
        yield return new WaitForSeconds(duration);
        _speedBoostImage.gameObject.SetActive(false);
    }
}
