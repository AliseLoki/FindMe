using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;
    [SerializeField] private TMP_Text _closeButtonText;
    [SerializeField] private TMP_Text _leaderboardName;
    [SerializeField] private TMP_Text _playerRankText;
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private TMP_Text _playerScoreText;

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

    private void InitButtonText()
    {
        _closeButtonText.text = _firstStartTextSO.CloseButtonText;
        _leaderboardName.text = _firstStartTextSO.LeaderbordName;
        _playerNameText.text = _firstStartTextSO.Name;
        _playerRankText.text = _firstStartTextSO.Place;
        _playerScoreText.text = _firstStartTextSO.DeliveredDishesName;
    }
}
