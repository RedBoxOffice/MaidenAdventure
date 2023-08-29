using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebGLSupport;
using WebGLInput = WebGLSupport.WebGLInput;

public class ControlEnterInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private UIRandomGenerator _randomGenerator;
    [SerializeField] private BonusPanel _bonusPanel;
    [SerializeField] private TextMeshProUGUI _textReward;
    [SerializeField] private ErrorPanel _errorPanel;
    [SerializeField] private TextMeshProUGUI _textAmountAttempts;
    [SerializeField] private HashAnimationsNames _animationsNames;
    [SerializeField] private FailedPanel _failedPanel;
    [SerializeField] private Storage _storage;   

    private List<string> _rightWordsRussian = new List<string>();
    private List<string> _rightWordsEnglish = new List<string>();
    private List<string> _rightWordsTurkish = new List<string>();
    private List<int> _scenes = new List<int>();
    private string _numberScene = "NumberScene";  
    private string _amountBonusScene = "AmountBonusScene";
    private string _russianRightWord;
    private string _englishRightWord;
    private string _turkishRightWord;
    private string _attempts = "AmountAttempts";
    private float _delayTimeForErrorPanel = 1.5f;
    private float _delayTimeForSaveDataBonusLevel = 1f;
    private float _delayTimeForActivateNextLevel = 4f;
    private int _amountAttempts = 3;
    private int _countBonusScene = 0;
    private int _sceneIndex = 2;
    private Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();

        if (PlayerPrefs.HasKey(_amountBonusScene))
        {            
            _countBonusScene = PlayerPrefs.GetInt(_amountBonusScene);            
        }

        AddWords();
        AddSceneInArray();
        Invoke(nameof(StartScriptForSaveDataBonusLevel), _delayTimeForSaveDataBonusLevel);

        if (PlayerPrefs.HasKey(_attempts))
        {
            _amountAttempts = PlayerPrefs.GetInt(_attempts);
        }      

        _textAmountAttempts.text = _amountAttempts.ToString();        
    }

    public void CheckWord()
    {
        if (_inputField.text.ToLower() == _russianRightWord.ToLower() 
            || _inputField.text.ToLower() == _englishRightWord.ToLower() 
            || _inputField.text.ToLower() == _turkishRightWord.ToLower())
        {            
            _randomGenerator.gameObject.SetActive(true);
            _bonusPanel.gameObject.SetActive(true);
            _textReward.gameObject.SetActive(true);
            gameObject.SetActive(false);
            _amountAttempts = 3;
            PlayerPrefs.SetInt(_attempts, _amountAttempts);          
        }
        else
        {
            _amountAttempts--;
            PlayerPrefs.SetInt(_attempts, _amountAttempts);
            _textAmountAttempts.text = _amountAttempts.ToString();
            _errorPanel.gameObject.SetActive(true);
            Invoke(nameof(DeactivateErrorPanel), _delayTimeForErrorPanel);

            if (_amountAttempts == 0)
            {
                ActivateFailedPanel();            
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(2);       
    }

    private void DeactivateErrorPanel()
    {
        _errorPanel.gameObject.SetActive(false);        
    }

    private void ActivateFailedPanel()
    {
        Invoke(nameof(LoadScene), _delayTimeForActivateNextLevel);
        gameObject.SetActive(false);        
        _failedPanel.gameObject.SetActive(true);
        _storage.SaveDataForFailedBonusLevel();
        _amountAttempts = 3;
        PlayerPrefs.SetInt(_attempts, _amountAttempts);
    }   
    
    private void AddWords()
    {
        _rightWordsRussian.Add("Страх");
        _rightWordsRussian.Add("Старость");
        _rightWordsEnglish.Add("Fear");
        _rightWordsEnglish.Add("Oldness");
        _rightWordsTurkish.Add("Korku");
        _rightWordsTurkish.Add("Ihtiyarl?k");
    }

    private void AddSceneInArray()
    {       
        if (!PlayerPrefs.HasKey(_numberScene + _scene.buildIndex))
        {
            PlayerPrefs.SetInt(_numberScene + _scene.buildIndex, _scene.buildIndex);
            PlayerPrefs.SetInt(_amountBonusScene, _countBonusScene + 1);                      
        }

        for (int i = 0; i < PlayerPrefs.GetInt(_amountBonusScene); i++)
        {
            _sceneIndex += 6;           
            _scenes.Add(PlayerPrefs.GetInt($"{_numberScene}{_sceneIndex}"));
        }        

        for (int i = 0; i < _rightWordsRussian.Count; i++)
        {          
            for (int j = 0; j < _scenes.Count; j++)
            {               
                if (i == j && _scene.buildIndex == _scenes[j])
                {                   
                    _russianRightWord = _rightWordsRussian[i];
                    break;
                }
            }
        }

        for (int i = 0; i < _rightWordsEnglish.Count; i++)
        {
            for (int j = 0; j < _scenes.Count; j++)
            {
                if (i == j && _scene.buildIndex == _scenes[j])
                {
                    _englishRightWord = _rightWordsEnglish[i];
                    break;
                }
            }
        }

        for (int i = 0; i < _rightWordsTurkish.Count; i++)
        {
            for (int j = 0; j < _scenes.Count; j++)
            {
                if (i == j && _scene.buildIndex == _scenes[j])
                {
                    _turkishRightWord = _rightWordsTurkish[i];
                    break;
                }
            }
        }
    }

    private void StartScriptForSaveDataBonusLevel()
    {
        _storage.SaveDataForBonusLevelToTransition();
    }
}
