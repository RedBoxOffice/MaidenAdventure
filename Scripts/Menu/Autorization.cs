using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autorization : MonoBehaviour
{
    private bool _doRequestOnPersonalData;
    private string _requestPersonalData = "RequestPersonalData";

    private void Awake()
    {
        _doRequestOnPersonalData = PlayerPrefs.GetInt(_requestPersonalData) != 0;

        if (_doRequestOnPersonalData == false)
        {
            PlayerAccount.Authorize();
            _doRequestOnPersonalData = true;
            PlayerPrefs.SetInt(_requestPersonalData, _doRequestOnPersonalData ? 1 : 0);

            if (PlayerAccount.IsAuthorized == true)
            {
                PlayerAccount.RequestPersonalProfileDataPermission();
            }
        }            
    }
}
