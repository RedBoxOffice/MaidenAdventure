using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{    
    [SerializeField] private Transform _path;
    [SerializeField] private SwitchPanelGame _switchPanelGame;
    [SerializeField] private Inventar _inventar;
    [SerializeField] private Connector _connector;
    [SerializeField] private Timer _timer;

    public readonly List<Transform> MovePoints = new List<Transform>();
    public readonly List<Transform> TempPoints = new List<Transform>();
    public event UnityAction <List<Transform>> Ending;
    public event UnityAction Congratulate;
    private string _openRoadCube = "OpenRoadCube";
    private string _indexSceneForSimpleLevel = "IndexSceneForSimpleLevel";
    private bool _canOpenRoadCube = false;
    private Scene _scene;

    public bool IsFinish { get; private set; } = false;

    private void OnEnable()
    {
        _connector.Linking += SetBoolRoadCube;
        _timer.OverTime += SetBoolRoadCube;
    }

    private void OnDisable()
    {
        _connector.Linking -= SetBoolRoadCube;
        _timer.OverTime -= SetBoolRoadCube;
    }

    private void Start()
    { 
        for (int i = 0; i < _path.childCount; i++)
        {
            MovePoints.Add(_path.GetChild(i));
        }

        if (PlayerPrefs.HasKey(_indexSceneForSimpleLevel + _scene.buildIndex))
        {
            _canOpenRoadCube = PlayerPrefs.GetInt(_openRoadCube) != 0;
        }

        _scene = SceneManager.GetActiveScene();
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeroDirection heroController))
        {
            _switchPanelGame.enabled = true;
            Congratulate?.Invoke();
            _inventar.DefaultAcceptReward();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Road road) && road.IsContactStartLevel == true && _canOpenRoadCube == true)
        {            
            IsFinish = true;

            for (int i = 0; i < road.TempPoints.Count; i++)
            {
                TempPoints.Add(road.TempPoints[i]);
            }

            for (int i = 0; i < MovePoints.Count; i++)
            {
                TempPoints.Add(MovePoints[i]);
            }

            Ending?.Invoke(TempPoints);
        }
        else
        {
            // Вы ещё не попытались забрать подсказку
        }
    }

    private void SetBoolRoadCube()
    {
        if (!PlayerPrefs.HasKey(_indexSceneForSimpleLevel))
        {
            PlayerPrefs.SetInt(_indexSceneForSimpleLevel + _scene.buildIndex, _scene.buildIndex);
            _canOpenRoadCube = true;
            PlayerPrefs.SetInt(_openRoadCube, _canOpenRoadCube ? 1 : 0);
        }        
    }
}
