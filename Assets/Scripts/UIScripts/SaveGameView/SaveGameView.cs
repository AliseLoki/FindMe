using System.Collections;
using TMPro;
using UnityEngine;

public class SaveGameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameSavedText;
    [SerializeField] private Player _player;

    private FirstStartTextSO _firstStartTextSO;

    private void Awake()
    {
        _gameSavedText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone += ShowText;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredSafeZone -= ShowText;
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
        InitText();
    }

    private void InitText()
    {
        _gameSavedText.text = _firstStartTextSO.SaveGameText;
    }

    private void ShowText()
    {
        _gameSavedText.gameObject.SetActive(true);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        int pause = 2;
        yield return new WaitForSeconds(pause);
        _gameSavedText.gameObject.SetActive(false);
        StopCoroutine(Timer());
    }
}
