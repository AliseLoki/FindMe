using System.Collections.Generic;
using UnityEngine;

namespace LeaderboardSystem
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

        private List<LeaderboardElement> _spawnedElements = new();

        public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
        {
            ClearLeaderboard();

            foreach (LeaderboardPlayer player in leaderboardPlayers)
            {
                LeaderboardElement leaderboardElement = Instantiate(_leaderboardElementPrefab, _container);
                leaderboardElement.Initialize(player.Name, player.Rank, player.Score);
                _spawnedElements.Add(leaderboardElement);
            }
        }

        private void ClearLeaderboard()
        {
            foreach (var element in _spawnedElements)
            {
                Destroy(element);
            }

            ClearContainer();

            _spawnedElements = new List<LeaderboardElement>();
        }

        private void ClearContainer()
        {
            foreach (Transform item in _container)
            {
                Destroy(item.gameObject);
            }
        }
    }
}