using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardGame : MonoBehaviour
{
    [SerializeField] private LeaderboardViewer _leaderboardViewer;

    private List<ResultPlayer> _resultPlayers = new List<ResultPlayer>();   
    private string _leaderboardName = "PlayersScore";      

    public void AddPlayer(int score)
    {
        Leaderboard.GetPlayerEntry(_leaderboardName, result =>
        {
            Leaderboard.SetScore(_leaderboardName, score);
        });
    }   

    public void GetLeaderboard()
    {
        ClearEntries();

        Leaderboard.GetEntries(_leaderboardName, result =>
        {
            int AmountEntries = result.entries.Length;
            AmountEntries = Mathf.Clamp(AmountEntries, 1, 5);

            for (int i = 0; i < AmountEntries; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "anonymous";

                int score = result.entries[i].score;               
                int rank = result.entries[i].rank;

                _resultPlayers.Add(new ResultPlayer(name, score, rank));
            }

            _leaderboardViewer.ShowLeaderboard(_resultPlayers);
        });
    }   

    private void ClearEntries()
    {
        _resultPlayers.Clear();
    }    
}
