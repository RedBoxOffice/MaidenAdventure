using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private StartLevel _startLevel;
    
    public readonly List<Transform> MovePoints = new List<Transform>();
    public List<Transform> TempPoints = new List<Transform>();
    
    public bool IsContactStartLevel { get; private set; } = false;

    private bool _isUseOnceWithNeighbour = false;

    private void Start()
    { 
        for (int i = 0; i < _path.childCount; i++)
        {
            MovePoints.Add(_path.GetChild(i));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out StartLevel startLevel) && _isUseOnceWithNeighbour == false)
        {
            IsContactStartLevel = true;
            _startLevel.SetTrueContactRoad();

            for (int i = 0; i < startLevel.MovePoints.Count; i++)
            {
                TempPoints.Add(startLevel.MovePoints[i]);
            }

            for (int i = 0; i < MovePoints.Count; i++)
            {
                TempPoints.Add(MovePoints[i]);
            }

            _isUseOnceWithNeighbour = true;
        }
        else if (other.TryGetComponent(out Road road) && road.IsContactStartLevel == true && _startLevel.IsContactRoad == true && _isUseOnceWithNeighbour == false)
        {
            IsContactStartLevel = true;

            for (int i = 0; i < road.TempPoints.Count; i++)
            {
                TempPoints.Add(road.TempPoints[i]);
            }

            for (int i = 0; i < MovePoints.Count; i++)
            {
                TempPoints.Add(MovePoints[i]);
            }

            _isUseOnceWithNeighbour = true;
        }
        
        if (_startLevel.IsContactRoad == false)
        {
            _isUseOnceWithNeighbour = false;
            IsContactStartLevel = false;
            TempPoints.Clear();
        }
    }   

    private void OnTriggerExit(Collider other)
    {
        _startLevel.SetFalseContactRoad();
        _isUseOnceWithNeighbour = false;
        IsContactStartLevel = false;
        TempPoints.Clear();
    }
}