using System.Collections;
using TMPro;
using UnityEngine;
using SO;

public class SaveGameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameSavedText;
    
    private FirstStartTextSO _firstStartTextSO;

    private void Awake()
    {
        _gameSavedText.gameObject.SetActive(false);
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
        InitText();
    }

    public void ShowText()
    {
        _gameSavedText.gameObject.SetActive(true);
        StartCoroutine(Timer());
    }

    private void InitText()
    {
        _gameSavedText.text = _firstStartTextSO.SaveGameText;
    }

    private IEnumerator Timer()
    {
        int pause = 2;
        yield return new WaitForSeconds(pause);
        _gameSavedText.gameObject.SetActive(false);
        StopCoroutine(Timer());
    }
}
