using Agava.YandexGames;
using UnityEngine;

public class DeliveredDishesCounter : MonoBehaviour
{
    private const string LeaderboardName = "LeaderboardPlayers";

    private const string PlayerPrefsDeliveredDishesNumber = nameof(PlayerPrefsDeliveredDishesNumber);

    private int _deliveredDishesNumber;

    public int DeliveredDishesNumber => _deliveredDishesNumber;

    private void Awake()
    {
        _deliveredDishesNumber = PlayerPrefs.GetInt(PlayerPrefsDeliveredDishesNumber, 0);
        PlayerPrefs.SetInt(PlayerPrefsDeliveredDishesNumber, _deliveredDishesNumber);
        PlayerPrefs.Save();
    }

    public void AddDeliveredDish()
    {
        _deliveredDishesNumber++;
        PlayerPrefs.SetInt(PlayerPrefsDeliveredDishesNumber, _deliveredDishesNumber);
        PlayerPrefs.Save();
        SetPlayerDeliveredDishesNumber(_deliveredDishesNumber);
    }

    private void SetPlayerDeliveredDishesNumber(int deliveredDishesNumber)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
 if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null || result.score < deliveredDishesNumber)
                Leaderboard.SetScore(LeaderboardName, deliveredDishesNumber);
        });
       
#endif
    }
}
