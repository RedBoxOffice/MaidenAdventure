using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{    
    [SerializeField] private MainPanel _mainPanel;
    [SerializeField] private LevelsPanel _levelsPanel;
    [SerializeField] private CluesPanel _cluesPanel;
    [SerializeField] private DirectionHero _directionHero;
    [SerializeField] private Storage _storage;
    
    public event UnityAction Continue;
    private float _delayTimeForLoadScene = 1.5f;

    public int ProgressLevel { get; private set; } = 0;

    private void Awake()
    {
        ProgressLevel = PlayerPrefs.GetInt(_storage.ProgressScene);
    }

    private void Start()
    {
        _mainPanel.gameObject.SetActive(false);
        _levelsPanel.gameObject.SetActive(false);
        _cluesPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _directionHero.Reached += ActivateMainPanel;
    }

    public void ContinueGame()
    {        
        Continue?.Invoke();        
        Invoke(nameof(LoadScene), _delayTimeForLoadScene);        
    }

    public void ChooseAnotherLevel()
    {
        _levelsPanel.gameObject.SetActive(true);
        _mainPanel.gameObject.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateCluesPanel()
    {
        _levelsPanel.gameObject.SetActive(false);
        _mainPanel.gameObject.SetActive(false);
        _cluesPanel.gameObject.SetActive(true);
    }


    private void LoadScene()
    {
        SceneManager.LoadScene(ProgressLevel + 1);
    }

    private void ActivateMainPanel()
    {
        _mainPanel.gameObject.SetActive(true);
        _mainPanel.SetText();
    }

    private void OnDisable()
    {
        _directionHero.Reached -= ActivateMainPanel;
    }
}
