using UnityEngine;
using YG;
using YG.Utils.LB;

public class DeliveredDishesCounter : MonoBehaviour
{
    private const string LeaderboardName = "LeaderboardPlayers";

    private const string PlayerPrefsDeliveredDishesNumber = nameof(PlayerPrefsDeliveredDishesNumber);

    private int _deliveredDishesNumber;

    private LBData _lb;

    public int DeliveredDishesNumber => _deliveredDishesNumber;

    private void Awake()
    {
        _deliveredDishesNumber = PlayerPrefs.GetInt(PlayerPrefsDeliveredDishesNumber, 0);
        PlayerPrefs.SetInt(PlayerPrefsDeliveredDishesNumber, _deliveredDishesNumber);
    }

    private void OnEnable()
    {
        YandexGame.onGetLeaderboard += OnGetLeaderboard;
    }

    private void OnDisable()
    {
        YandexGame.onGetLeaderboard -= OnGetLeaderboard;
    }

    public void AddDeliveredDish()
    {
        _deliveredDishesNumber++;
        PlayerPrefs.SetInt(PlayerPrefsDeliveredDishesNumber, _deliveredDishesNumber);
        YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
        SetPlayerDeliveredDishesNumber(_deliveredDishesNumber);
    }

    private void SetPlayerDeliveredDishesNumber(int deliveredDishesNumber)
    {
        if (YandexGame.auth == false)
        {
            return;
        }

        if (_lb.thisPlayer.score == 0 || _lb.thisPlayer.score < deliveredDishesNumber)
        {
           // _lb.thisPlayer.score = deliveredDishesNumber;
            YandexGame.NewLeaderboardScores(LeaderboardName, deliveredDishesNumber);
            YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
        }

        //#if UNITY_WEBGL && !UNITY_EDITOR
        // if (PlayerAccount.IsAuthorized == false)
        //        {
        //            return;
        //        }

        //    Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        //        {
        //            if (result == null || result.score < deliveredDishesNumber)
        //                Leaderboard.SetScore(LeaderboardName, deliveredDishesNumber);
        //        });

        //#endif
    }

    private void OnGetLeaderboard(LBData lb)
    {
        _lb = lb;
    }
}
