using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;
    [SerializeField] private TMP_Text _closeButtonText;

    private FirstStartTextSO _firstStartTextSO;

    private List<LeaderboardElement> _spawnedElements = new();

    private void Start()
    {
        InitButtonText();
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
    }

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

        _spawnedElements = new List<LeaderboardElement>();
    }

    private void InitButtonText()
    {
        _closeButtonText.text = _firstStartTextSO.CloseButtonText;
    }
}
