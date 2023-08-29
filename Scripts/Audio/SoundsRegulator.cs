using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsRegulator : MonoBehaviour
{
    [SerializeField] private AudioButton _audioButtonOn;
    [SerializeField] private AudioButton _audioButtonOff;

    public string StatusMusic { get; } = "StatusMusic";

    private AudioSource _audioSource;    
    private bool _isEnableMusic = true;
    private float _timeOfDelay = 0.4f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey(StatusMusic))
        {
            _isEnableMusic = PlayerPrefs.GetInt(StatusMusic) != 0;
        }

        if (_isEnableMusic == true)        
            Invoke(nameof(EnableSound), _timeOfDelay);        
        else
            Invoke(nameof(DisableSound), _timeOfDelay);      
    }

    public void DisableSound()
    {
        _audioButtonOn.gameObject.SetActive(false);
        _audioButtonOff.gameObject.SetActive(true);
        _audioSource.Pause();
        _isEnableMusic = false;
        PlayerPrefs.SetInt(StatusMusic, _isEnableMusic ? 1 : 0);
    }

    public void EnableSound()
    {      
        _audioButtonOn.gameObject.SetActive(true);
        _audioButtonOff.gameObject.SetActive(false);
        _audioSource.Play();
        _isEnableMusic = true;
        PlayerPrefs.SetInt(StatusMusic, _isEnableMusic ? 1 : 0);
    }
}
