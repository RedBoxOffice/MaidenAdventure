using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private Transform _path;

    public readonly List<Transform> MovePoints = new List<Transform>();

    public bool IsContactRoad { get; private set; } = false;

    private void Start()
    {
        for (int i = 0; i < _path.childCount; i++)
        {
            MovePoints.Add(_path.GetChild(i));
        }
    }

    public void SetFalseContactRoad()
    {
        IsContactRoad = false;
    }

    public void SetTrueContactRoad()
    {
        IsContactRoad = true;
    }
}
