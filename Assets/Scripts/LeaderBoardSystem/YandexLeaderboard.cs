using SettingsForYG;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;
using YG.Utils.LB;

namespace LeaderboardSystem
{
    public class YandexLeaderboard : MonoBehaviour
    {
        [SerializeField] private LeaderboardView _leaderboardView;
        [SerializeField] private TMP_Text _leaderboardName;
        [SerializeField] private TMP_Text _playerNameText;
        [SerializeField] private TMP_Text _playerScoreText;

        private string _anonymousName;
        private LBData _lb;
        private List<LeaderboardPlayer> _leaderboardPlayers = new();

        private void OnEnable()
        {
            YandexGame.onGetLeaderboard += OnGetLeaderboard;
        }

        private void OnDisable()
        {
            YandexGame.onGetLeaderboard -= OnGetLeaderboard;
        }

        public void InitLanguage(AllPhrases phrases)
        {
            _anonymousName = phrases.AnonymousName;
            _leaderboardName.text = phrases.LeaderbordName;
            _playerNameText.text = phrases.Name;
            _playerScoreText.text = phrases.DeliveredDishesName;

            MakeAllTextSameSize(_playerNameText, _playerScoreText);
        }

        public void Fill()
        {
            if (YandexGame.auth == false)
            {
                return;
            }

            _leaderboardPlayers.Clear();

            foreach (var item in _lb.players)
            {
                int rank = item.rank;
                int score = item.score;
                string name = item.name;
                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));

                if (string.IsNullOrEmpty(name))
                {
                    name = _anonymousName;
                }
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        }

        private void OnGetLeaderboard(LBData lb)
        {
            _lb = lb;
        }

        private void MakeAllTextSameSize(TMP_Text firstText, TMP_Text secondText)
        {
            if (firstText.fontSize > secondText.fontSize)
            {
                firstText.fontSize = secondText.fontSize;
            }
            else
            {
                secondText.fontSize = firstText.fontSize;
            }
        }
    }
}