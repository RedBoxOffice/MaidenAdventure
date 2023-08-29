using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOnHeroForCamera : MonoBehaviour
{
    [SerializeField] private HeroDirection _directionHero;

    private Vector3 _targetVector;
    private Vector3 _realVector;    

    private void Start()
    {
        if (_directionHero != null)
            MakeVector();        
    }

    private void Update()
    {
        if (_directionHero != null)
            MoveToHero();
    }

    private void MakeVector()
    {
        _targetVector.x = _directionHero.transform.position.x - transform.position.x;
        _targetVector.z = _directionHero.transform.position.z - transform.position.z;
        _targetVector.y = _directionHero.transform.position.y - transform.position.y;
    }

    private void MoveToHero() 
    {
        _realVector.x = _directionHero.transform.position.x - transform.position.x;
        _realVector.z = _directionHero.transform.position.z - transform.position.z;
        
        if (_targetVector != _realVector)
        {
            transform.position = _directionHero.transform.position - _targetVector; 
        }
    }
}
