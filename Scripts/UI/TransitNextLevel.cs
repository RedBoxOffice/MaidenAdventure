using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitNextLevel : MonoBehaviour
{
    [SerializeField] private DirectionCamera _directionCamera;
    [SerializeField] private Transform _endTransitPoint;
    [SerializeField] private Transform _targetQuaternionPoint;

    public void MoveCamera()
    {
        _directionCamera.SetNewCoordinats(_targetQuaternionPoint.transform.rotation, _endTransitPoint);
    }
}
