# pragma warning disable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agava.YandexGames.Samples;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class InitializingSDK : MonoBehaviour
{  
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(onSuccessCallback: LoadScene);          
    }    

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
