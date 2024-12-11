using System.Collections.Generic;
using UnityEngine;
using YG;
using YG.Utils.LB;

public class YandexLeaderboard : MonoBehaviour
{
    private string AnonymousName;
    private LBData _lb;

    private List<LeaderboardPlayer> _leaderboardPlayers = new();

    [SerializeField] private LeaderboardView _leaderboardView;

    private FirstStartTextSO _firstStartTextSO;

    private void Start()
    {
        InitAnonymousTranslation();
    }

    private void OnEnable()
    {
        YandexGame.onGetLeaderboard += OnGetLeaderboard;
    }

    private void OnDisable()
    {
        YandexGame.onGetLeaderboard -= OnGetLeaderboard;
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
    {
        _firstStartTextSO = firstStartTextSO;
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
                name = AnonymousName;
            }
        }

        _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
    }

    private void OnGetLeaderboard(LBData lb)
    {
        _lb = lb;
    }

    private void InitAnonymousTranslation()
    {
        AnonymousName = _firstStartTextSO.AnonymousName;
    }
}
