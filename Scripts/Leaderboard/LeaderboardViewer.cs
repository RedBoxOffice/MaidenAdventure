using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardViewer : MonoBehaviour
{
    [SerializeField] private Transform _scrollViewContent;
    [SerializeField] private UIPlayerInfo _uIPlayerInfo;

    private List<UIPlayerInfo> _spawnedResultPlayersOnLeaderboard = new List<UIPlayerInfo>();

    public void ShowLeaderboard(List<ResultPlayer> resultPlayers)
    {
        ClearResultPlayer();

        for (int i = 0; i < resultPlayers.Count; i++)
        {
            UIPlayerInfo resultPlayer = Instantiate(_uIPlayerInfo, _scrollViewContent);
            resultPlayer.ShowInfo(resultPlayers[i]);
            _spawnedResultPlayersOnLeaderboard.Add(resultPlayer);
        }
    }

    private void ClearResultPlayer()
    {
        foreach (var resultPlayer in _spawnedResultPlayersOnLeaderboard)
        {
            Destroy(resultPlayer.gameObject);
        }

        _spawnedResultPlayersOnLeaderboard = new List<UIPlayerInfo>();
    }
}
