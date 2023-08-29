using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimationsNames))]
public class PanelSwitch : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private SettingsMenu _settingsMenu;   
    [SerializeField] private ShowLevel _showLevel;
    [SerializeField] private ScrollRect _scrollRect;

    private string _key = "ProgressLevel";
    private Animator _animator;
    private HashAnimationsNames _animationsNames;
    private float _timeToChangeAnim = 0.01f;
    private float _delayTimeForChangeScene = 1.5f;

    private void Start()
    {       
        _animator = GetComponent<Animator>();
        _animationsNames = GetComponent<HashAnimationsNames>();
    }

    public void StartGame()
    {
        _mainMenu.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey(_key))
        {
            _showLevel.gameObject.SetActive(true);
        }
        else
        {
            _animator.CrossFade(_animationsNames.SceneSwitchAnim, _timeToChangeAnim);
            Invoke(nameof(ActivateStartScene), _delayTimeForChangeScene);           
        }   
    }

    public void ActivateSettings()
    {
        _mainMenu.gameObject.SetActive(false);
        _settingsMenu.gameObject.SetActive(true);
    }   

    public void ExitGame()
    {
        Application.Quit();
    } 
    
    public void ContinueGame()
    {
        _animator.CrossFade(_animationsNames.SceneSwitchAnim, _timeToChangeAnim);
        Invoke(nameof(ActivateTransitionScene), _delayTimeForChangeScene);
    }

    public void ActivateScrollView()
    {
        _scrollRect.gameObject.SetActive(true);
    }

    public void ActivateMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        
        if (_settingsMenu.gameObject.activeSelf == true)
        {
            _settingsMenu.gameObject.SetActive(false);
        }
        else if (_showLevel.gameObject.activeSelf == true)
        {
            _showLevel.gameObject.SetActive(false);
        }       
    }

    private void ActivateStartScene()
    {
        SceneManager.LoadScene(3);
    }   

    private void ActivateTransitionScene()
    {
        SceneManager.LoadScene(2);
    }
}
