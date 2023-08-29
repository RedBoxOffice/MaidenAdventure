using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class ResultPlayer : MonoBehaviour
{
    public string Name { get; private set; }
    public int Score { get; private set; }
    public int Rank { get; private set; }

    public ResultPlayer(string name, int score, int rank)
    {
        Name = name;
        Score = score;
        Rank = rank;
    }      
}
