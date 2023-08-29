using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimationsNames))]
public class DirectionHero : MonoBehaviour
{
    [SerializeField] private PointsDirection _pointsDirection;
    [SerializeField] private float _moveSpeedCharacter;
    [SerializeField] private Action _action;   
    [SerializeField] private SavePointPlayer _saveLoadManager;   
    [SerializeField] private Storage _storage;   
   
    public event UnityAction Reached;
    private Animator _animator;     
    private bool _isReachedPoint = false;
    private int _point;
    private float _delayTimeForChangeAnimation = 0.01f;
    private HashAnimationsNames _animationsNames;
   
    private void OnEnable()
    {
        _action.Continue += SetBool;
    }

    private void OnDisable()
    {
        _action.Continue -= SetBool;
    }

    private void Start()
    {        
        _animator = GetComponent<Animator>();        
        _animationsNames = GetComponent<HashAnimationsNames>();

        if (PlayerPrefs.HasKey(_storage.PointOfPlayerDirection))
        {          
            _point = PlayerPrefs.GetInt(_storage.PointOfPlayerDirection);           
        }      
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (_isReachedPoint == false)
        {
            _animator.CrossFade(_animationsNames.TorchRun, _delayTimeForChangeAnimation * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _pointsDirection.Pointers[_point].position, _moveSpeedCharacter * Time.deltaTime); 
            
            if (transform.position == _pointsDirection.Pointers[_point].position && _point == 2)
            {
                _point = 3;
                transform.position = _pointsDirection.Pointers[_point].position;
                _point = 0;
                PlayerPrefs.SetInt(_storage.PointOfPlayerDirection, _point);
            }
            else if (transform.position == _pointsDirection.Pointers[_point].position)
            {                
                _isReachedPoint = true;
                Reached?.Invoke();
                _saveLoadManager.SaveGame();
            }            
        }
        else if (_isReachedPoint == true)
        {           
            _animator.CrossFade(_animationsNames.TorchIdle, _delayTimeForChangeAnimation * Time.deltaTime);            
        }       
    }   

    private void SetBool()
    {       
        PlayerPrefs.SetInt(_storage.PointOfPlayerDirection, _point);           
        _saveLoadManager.SaveGame();
    }

    public void LoadData(Save.CharacterSaveData save)
    {
        transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);          
    }    
}
