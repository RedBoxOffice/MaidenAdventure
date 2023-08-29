using Plugins.Audio.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestAudio : MonoBehaviour
{
    [SerializeField] private SourceAudio _source;

    private Scene _scene;
    private int _transitLevelBuildIndex = 2;
    private float _timeOfDelay = 0.1f;

    private void Start()
    {       
        _scene = SceneManager.GetActiveScene();
        Invoke(nameof(ActivateMusic), _timeOfDelay);
    }
    
    private void ActivateMusic()
    {      
        if (_scene.buildIndex != _transitLevelBuildIndex)
            _source.Play("2");
        else
        {
            _source.Play("1");
        }
    }
}
