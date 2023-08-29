using UnityEngine;

public abstract class Advertisment : MonoBehaviour
{
    [SerializeField] private AudioSource _audioListener;
    [SerializeField] protected Storage _storage;

    public abstract void ShowAd();

    protected void OpenAd()
    {
        Time.timeScale = 0;
        _audioListener.enabled = false;
    }

    protected void CloseAd()
    {
        Time.timeScale = 1;
        _audioListener.enabled = true;
    }

    protected void CloseInterstitialAd(bool state)
    {
        if (state == true)
        {
            _audioListener.enabled = true;
            Time.timeScale = 1;
        }
    }
}
