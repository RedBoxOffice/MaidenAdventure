using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SwitchPanelGame : MonoBehaviour
{
    [SerializeField] private Connector _connector;
    [SerializeField] private EndLevel _endLevel;
    [SerializeField] private Timer _timer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _textMoney;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private InsctructionPanel _instructionPanel;

    private ScrollPanel _scrollPanel;
    private GameProgress _gameProgress;
    private EndLevelPanel _endLevelPanel;
    private RealTimePanel _realTimePanel;
    private LocalGameMenu _localGameMenu;    
    private float _delayTimeForEndLevelPanels = 9.5f;   
    private float _delayTimeForGameProgress = 4f;
    private bool _isActivateInstructionPanel = false;
    private string _activateInstructionPanel = "ActivateInstructionPanel";    

    private void OnEnable()
    {
        _connector.Linking += ActivateRewardPanels;
        _endLevel.Congratulate += DelayTimeForActivateEndLevelsPanel;       
    }    

    private void Start()
    {
        _scrollPanel = GetComponentInChildren<ScrollPanel>();
        _endLevelPanel = GetComponentInChildren<EndLevelPanel>();
        _gameProgress = GetComponentInChildren<GameProgress>();
        _realTimePanel = GetComponentInChildren<RealTimePanel>();
        _localGameMenu = GetComponentInChildren<LocalGameMenu>();      
        _scrollPanel.gameObject.SetActive(false);
        _gameProgress.gameObject.SetActive(false);
        _endLevelPanel.gameObject.SetActive(false);
        _localGameMenu.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey(_activateInstructionPanel))
            _isActivateInstructionPanel = PlayerPrefs.GetInt(_activateInstructionPanel) != 0;

        if (_isActivateInstructionPanel == false)
            ActivateInstructionGame();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ActivateLocalMenu()
    {
        Time.timeScale = 0;
        _localGameMenu.gameObject.SetActive(true);
    }

    public void DeactivateLocalMenu()
    {
        Time.timeScale = 1;
        _localGameMenu.gameObject.SetActive(false);
    }    

    public void DeactivateGamePanels()
    {       
        Time.timeScale = 1;
        _scrollPanel.gameObject.SetActive(false);
        _realTimePanel.gameObject.SetActive(false);
        this.enabled = false;
    } 
    
    public void DeactivateInstructionPanel()
    {
        _instructionPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void ActivateRewardPanels()
    {
        Time.timeScale = 0;
        _gameProgress.gameObject.SetActive(true);
        _scrollPanel.gameObject.SetActive(true);
    }

    private void DelayTimeForActivateEndLevelsPanel()
    {
        Invoke(nameof(ActivateEndGameProgress), _delayTimeForGameProgress);
        Invoke(nameof(ActivateEndLevelPanel), _delayTimeForEndLevelPanels);
    }   

    private void ActivateEndGameProgress()
    {
        _gameProgress.gameObject.SetActive(true);
        _textMoney.text = _wallet.Money.ToString();
    }

    private void ActivateEndLevelPanel()
    {
        _endLevelPanel.gameObject.SetActive(true);       
    }

    private void OnDisable()
    {
        _connector.Linking -= ActivateRewardPanels;
        _endLevel.Congratulate -= DelayTimeForActivateEndLevelsPanel;
    }

    private void ActivateInstructionGame()
    {
        _instructionPanel.gameObject.SetActive(true);
        _isActivateInstructionPanel = true;
        PlayerPrefs.SetInt(_activateInstructionPanel, _isActivateInstructionPanel ? 1 : 0);
        Time.timeScale = 0;
    }
}
