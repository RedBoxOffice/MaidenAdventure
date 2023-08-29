using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class Timer : MonoBehaviour
{     
    [SerializeField] private Camera _camera;  
    [SerializeField] private float _timeLeft;   

    public event UnityAction<float,float> RealTime;
    public event UnityAction OverTime;
    private float _minutes = 0;
    private float _seconds = 0;
    private int _tempTime;
    private int _timeToSave = 15;
    private string _antiCheatTime = "AntiCheatTime";
    private Scene scene;   

    public float TimeLeft => _timeLeft;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (PlayerPrefs.HasKey(_antiCheatTime + scene.buildIndex))
        {
            _timeLeft = PlayerPrefs.GetFloat(_antiCheatTime + scene.buildIndex);
        }
    }

    private void Update()
    {
        if (transform.position == _camera.gameObject.transform.position)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
            }
            else
            {                
                _timeLeft = 0;
                OverTime?.Invoke();                
            }

            UpdateTimeText();
        }
        else
        {
            UpdateTimeText();
        }
    }  
    
    public void CancelTime()
    {       
        _timeLeft = 0;
        PlayerPrefs.SetFloat(_antiCheatTime + scene.buildIndex, _timeLeft);        
    }

    private void UpdateTimeText()
    {
        _tempTime = Mathf.RoundToInt(_timeLeft);

        if (_tempTime % _timeToSave == 0)
        {
            PlayerPrefs.SetFloat(_antiCheatTime + scene.buildIndex, _timeLeft);
        }

        _minutes = Mathf.FloorToInt(_timeLeft / 60);
        _seconds = Mathf.FloorToInt(_timeLeft % 60);
        RealTime?.Invoke(_minutes, _seconds);        
    }    
}