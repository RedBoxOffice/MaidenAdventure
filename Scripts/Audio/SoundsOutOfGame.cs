using Agava.WebUtility;
using UnityEngine;

[RequireComponent(typeof(SoundsRegulator))]
public class SoundsOutOfGame : MonoBehaviour
{
    private SoundsRegulator _soundsRegulator;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void Start()
    {
        _soundsRegulator = GetComponent<SoundsRegulator>();
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {       
        if (PlayerPrefs.GetInt(_soundsRegulator.StatusMusic) != 0 == true)
        {            
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }       
    }
}
