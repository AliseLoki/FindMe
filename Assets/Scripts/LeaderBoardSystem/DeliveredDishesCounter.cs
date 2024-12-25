using UnityEngine;
using YG;

namespace LeaderboardSystem
{
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

            YandexGame.NewLeaderboardScores(LeaderboardName, deliveredDishesNumber);
        }
    }
}
