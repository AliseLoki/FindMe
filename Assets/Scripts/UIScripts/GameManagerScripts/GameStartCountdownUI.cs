using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _countdownText;
    //[SerializeField] private TMP_Text _remainingTimeText;

    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private float _timer = 2f;
    private FirstStartTextSO _firstStartTextSO;

    private void Start()
    {
        ChangeLanguage();
    }

    private void Update()
    {
        //if (_remainingTimeText.isActiveAndEnabled)
        //{
        //    CountDownToAd();
        //}
        //else
        //{
            CountdownToStart();
        //}
    }

    public void InitText(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
    }

    public void ShowBeforeAdWarning()
    {
      //  _remainingTimeText.gameObject.SetActive(true);
    }

    private void ChangeLanguage()
    {
      //  _remainingTimeText.text = _firstStartTextSO.RemainingTimeText;
    }

    private void CountDownToAd()
    {
        _timer -= Time.deltaTime;
        _countdownText.text = Mathf.Ceil(_timer).ToString();

        if (_timer < 0f)
        {
            _timer = 2f;
        }
    }

    private void CountdownToStart()
    {
        _countdownText.text = Mathf.Ceil(_gameStatesSwitcher.GetCountdownToStartTimer()).ToString();
    }
}
