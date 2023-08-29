using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class VideoAdShow : Advertisment
{
    [SerializeField] private CluesOnPanel _cluesOnPanel;

    private int _indexScene = 3;

    public override void ShowAd()
    {
        VideoAd.Show(OpenAd, SetReward, CloseAd);       
    }

    private void SetReward()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(_storage.CountWords); i++)
        {
            if (PlayerPrefs.GetString($"{_storage.PlayerClue}{i + _indexScene}") == "")
            {
                PlayerPrefs.SetString($"{_storage.PlayerClue}{i + _indexScene}", _storage.AllClues[i]);
                break;
            }
            

            if (i >= 4 && (i + 1) % 5 == 0)
            {
                _indexScene += 1;
            }
        }

        _storage.ReloadData();
        _cluesOnPanel.RewriteArray();
    }   
}
