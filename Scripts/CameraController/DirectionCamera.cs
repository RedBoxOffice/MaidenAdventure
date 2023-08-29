using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionCamera : MonoBehaviour
{
    [SerializeField] private List<PointOnHeroForCamera> _point;
    [SerializeField] private float _deltaDistance;
    [SerializeField] private EndLevel _endLevel;
    [SerializeField] private Transform _lookPoint;    
    [SerializeField] private Transform _lastPoint;

    private int _indexPoint = 0;
    private float _speedEndDirection = 1.5f;
    private float _rotationSpeed = 10f;
    private Quaternion _quaternion = Quaternion.Euler(0, 180, 0);

    public bool IsReachTargetPoint { get; private set; } = false;

    private void Update()
    {
        if (_endLevel.IsFinish == false)
        {            
            MoveCamera();
            LookAtHero(_lookPoint);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _lastPoint.transform.position, _speedEndDirection * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _quaternion, _rotationSpeed * Time.deltaTime);
            IsReachTargetPoint = false;
        }       
    }

    public void SetNewCoordinats(Quaternion coordinats, Transform vector3)
    {
        _quaternion = coordinats;
        _lastPoint = vector3;
    }

    private void MoveCamera()
    {       
        transform.position = Vector3.MoveTowards(transform.position, _point[_indexPoint].transform.position, _deltaDistance * Time.deltaTime);

        if (transform.position == _point[_indexPoint].transform.position && _indexPoint < _point.Count - 1)
        {
            _indexPoint++;           
        }   
        else if (_indexPoint == _point.Count - 1 && transform.position == _point[_indexPoint].transform.position)
        {
            IsReachTargetPoint = true;              
        }        
    }

    private void LookAtHero(Transform point)
    {
        transform.LookAt(point);
    }
}
