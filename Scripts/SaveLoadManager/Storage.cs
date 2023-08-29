using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class Storage : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Bag _bag;
    [SerializeField] private UIRandomGenerator _randomGenerator;

    public readonly List<string> AllClues = new List<string>();
    public readonly List<string> Clues = new List<string>();   
    
    private string _playerMoney = "PlayerMoney";   
    private string _controlEnterBonusLevel = "ControlEnterBonusLevel";    
    private int _numberPointDirectionPlayer = -1;
    private int _numberLevel = 1;
    private int _bonusLevel = 0;
    private int _indexOfStartGame = 3;   
    private bool _boolBonusLevel = true;
    private bool _isActivateBonusLevel = false;
    private Scene _scene;

    public string PlayerClue = "PlayerClue";
    public string CountWords { get; } = "CountWords";   
    public string ProgressScene { get; } = "ProgressLevel";
    public string TextLevel { get; } = "TextLevel";
    public string PointOfPlayerDirection { get; } = "PointOfPlayerDirection";
    public string Bonuslevel { get; } = "BonusLevel";
    public string BoolBonusLevel { get; } = "BoolBonusLevel";
    public string ControlForChangeText { get; } = "ControlForChangeText";
    public int StaticPlayerMoney { get; private set; } = 0;
   

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        LoadData();
    }

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        AddClues();         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Camera camera))
        {
            SaveDataForSimpleLevel();            
        }       
    }

    public void SaveDataForSuccessBonusLevel()
    {
        StaticPlayerMoney += _randomGenerator.TempMoney;
        PlayerPrefs.SetInt(_playerMoney, StaticPlayerMoney);
        _boolBonusLevel = false;
        PlayerPrefs.SetInt(BoolBonusLevel, _boolBonusLevel ? 1 : 0);
    } 
    
    public void SaveDataForFailedBonusLevel()
    {
        _boolBonusLevel = false;
        PlayerPrefs.SetInt(BoolBonusLevel, _boolBonusLevel ? 1 : 0);
    }

    public void SaveDataForBonusLevelToTransition()
    {
        if (!PlayerPrefs.HasKey(_controlEnterBonusLevel + _scene.buildIndex))
        {
            _isActivateBonusLevel = true;
            PlayerPrefs.SetInt(ControlForChangeText, _isActivateBonusLevel ? 1 : 0);
            _boolBonusLevel = true;
            PlayerPrefs.SetInt(BoolBonusLevel, _boolBonusLevel ? 1 : 0);
            PlayerPrefs.SetInt(PointOfPlayerDirection, _numberPointDirectionPlayer + 1);
            PlayerPrefs.SetInt(_controlEnterBonusLevel + _scene.buildIndex, _scene.buildIndex);
            PlayerPrefs.SetInt(Bonuslevel, _bonusLevel + 1);
            PlayerPrefs.SetInt(ProgressScene, _scene.buildIndex);
        }        
    }   

    private void SaveDataForSimpleLevel()
    {        
        PlayerPrefs.SetInt(_playerMoney, _wallet.Money);
        _isActivateBonusLevel = false;
        PlayerPrefs.SetInt(ControlForChangeText, _isActivateBonusLevel ? 1 : 0);

        if (!PlayerPrefs.HasKey(PlayerClue + _scene.buildIndex))
        {           
            PlayerPrefs.SetInt(TextLevel, _numberLevel + 1);
            PlayerPrefs.SetInt(PointOfPlayerDirection, _numberPointDirectionPlayer + 1);           
            PlayerPrefs.SetInt(ProgressScene, _scene.buildIndex);

            if (_bag.GetWord() != null)
            {                
              PlayerPrefs.SetString(PlayerClue + _scene.buildIndex, _bag.GetWord().text);
               Clues.Add(PlayerPrefs.GetString(PlayerClue + _scene.buildIndex));

            }
            else
            {                
             PlayerPrefs.SetString(PlayerClue + _scene.buildIndex, "");
               Clues.Add(PlayerPrefs.GetString(PlayerClue + _scene.buildIndex));
            }
        }     

        PlayerPrefs.SetInt(CountWords, Clues.Count);       
    }

    public void ReloadData()
    {
        Clues.Clear();
        _indexOfStartGame = 3;

        for (int i = 0; i < PlayerPrefs.GetInt(CountWords); i++)
        {
            Clues.Add(PlayerPrefs.GetString($"{PlayerClue}{i + _indexOfStartGame}"));

            if (i >= 4 && (i + 1) % 5 == 0)
            {
                _indexOfStartGame += 1;
            }
        }
    }

    private void LoadData()
    {        
        StaticPlayerMoney = PlayerPrefs.GetInt(_playerMoney);

        for (int i = 0; i < PlayerPrefs.GetInt(CountWords); i++)
        {            
            Clues.Add(PlayerPrefs.GetString($"{PlayerClue}{i + _indexOfStartGame}"));      
            
            if (i >= 4 && (i + 1) % 5 == 0)
            {
                _indexOfStartGame += 1;
            }
        }        

        if (PlayerPrefs.HasKey(TextLevel) && PlayerPrefs.HasKey(PointOfPlayerDirection))
        {
            _numberLevel = PlayerPrefs.GetInt(TextLevel);
            _numberPointDirectionPlayer = PlayerPrefs.GetInt(PointOfPlayerDirection);            
        } 
        
        if (!PlayerPrefs.HasKey(Bonuslevel))
        {
            _bonusLevel = PlayerPrefs.GetInt(Bonuslevel);
        }          
    }  
    
    private void AddClues()
    {
        AllClues.Add("Ночь");
        AllClues.Add("Смерть");
        AllClues.Add("Война");
        AllClues.Add("Фобия");
        AllClues.Add("Адреналин");
        AllClues.Add("Время");
        AllClues.Add("Болезнь");
        AllClues.Add("Память");
        AllClues.Add("Конец");
        AllClues.Add("Внук");       
    }
}