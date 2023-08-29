using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class IntersitialAd : Advertisment
{
    private void Start()
    {
        ShowAd();            
    }

    public override void ShowAd()
    {
        InterstitialAd.Show(OpenAd, CloseInterstitialAd);
    }    
}
