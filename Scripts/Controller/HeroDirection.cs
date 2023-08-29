using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimationsNames))]
public class HeroDirection : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private EndLevel _endLevel;

    private List<Transform> _pointers = new List<Transform>();
    private int _indexPoint = 0;
    private float _timeToChangeAnimation = 0.09f;
    private bool _isUseAnimation = false;
    private string _animationSamba = "Samba";
    private Animator _animator;
    private HashAnimationsNames _animationsNames;

    private void OnEnable()
    {
        _endLevel.Ending += MoveToPoint;
    }

    private void OnDisable()
    {
        _endLevel.Ending -= MoveToPoint;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animationsNames = GetComponent<HashAnimationsNames>();
    }

    private void Update()
    {
        if (_endLevel.IsFinish == true && transform.position != _endLevel.MovePoints[0].transform.position)
        {
            _animator.CrossFade(_animationsNames.Running, _timeToChangeAnimation * Time.deltaTime);
            MoveHero();        
        }    
        else if (_endLevel.IsFinish == true && transform.position == _endLevel.MovePoints[0].transform.position)
        {
            if (_isUseAnimation == false)
            {                
                _animator.CrossFade(_animationsNames.RightTurn, _timeToChangeAnimation * Time.deltaTime);
                _isUseAnimation = true;
                _animator.SetBool(_animationSamba, true);                
            }            
        }
        else
        {
            _animator.CrossFade(_animationsNames.Idle, _timeToChangeAnimation * Time.deltaTime);
        }
    }

    private void MoveHero()
    {        
        transform.position = Vector3.MoveTowards(transform.position, _pointers[_indexPoint].position, _moveSpeed * Time.deltaTime);
        transform.LookAt(_pointers[_indexPoint].position);

        if (transform.position == _pointers[_indexPoint].position)
        {
            _indexPoint++;
        }
    }     
    
    private void MoveToPoint(List<Transform> pointers)
    {
        _pointers = pointers;
    }    
}
