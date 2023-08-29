using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDirection : MonoBehaviour
{
    [SerializeField] private Transform _mainPoint;

    public readonly List<Transform> Pointers = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < _mainPoint.childCount; i++)
        {
            Pointers.Add(_mainPoint.GetChild(i));
        }
    }   
}
