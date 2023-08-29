using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareDirectionCube : MonoBehaviour
{
    private const float _timeToDone = 0.001f;
    private DirectionCamera _directionCamera;
    private float _distanceDelta = 0.1f;
    private List<Vector3> _directions;
    private float _vectorToCube = 1.25f;
    private MapGenerator _mapGenerator;
    private Vector3 _tempVector;
    private Vector3 _findVector;
    private Cube _emptyCube;
    private Vector3 _emptyCubeCoordinate;
    private bool _isFindEmptyCube = false;    
    private WaitForSeconds _timeDone = new WaitForSeconds(_timeToDone);

    private void Start()
    {
        _mapGenerator = FindObjectOfType<MapGenerator>();
        _directionCamera = FindObjectOfType<DirectionCamera>();
        _directions = new List<Vector3>();
        AddDirections();
    }
   
    private void AddDirections()
    {
        _directions.Add(Vector3.forward * _vectorToCube);
        _directions.Add(Vector3.back * _vectorToCube);
        _directions.Add(Vector3.right * _vectorToCube);
        _directions.Add(Vector3.left * _vectorToCube);
    }

    private void OnMouseDown()
    {
        if (_isFindEmptyCube == true || _directionCamera.IsReachTargetPoint == false)
            return;

        foreach (var direction in _directions)
        {
            _tempVector = transform.position;
            _findVector = transform.position + direction;
            _emptyCube = _mapGenerator.TransferCoordinateCube(_findVector);            

            if (_emptyCube != null)
            {
                _emptyCubeCoordinate = _emptyCube.transform.position;
                _isFindEmptyCube = true;
                StartCoroutine(MoveCubeThroughCoroutine());               
                break;
            }
        }
    }   

    private IEnumerator MoveCubeThroughCoroutine()
    {
        while (transform.position != _emptyCubeCoordinate)
        {           
            transform.position = Vector3.MoveTowards(transform.position, _emptyCubeCoordinate, _distanceDelta);
            FindObjectOfType<EmptyCube>().MoveOnCubePosition(_tempVector);
            yield return _timeDone;
        }

        if (transform.position == _emptyCubeCoordinate)
        {
            _isFindEmptyCube = false;
        }
    }
}
