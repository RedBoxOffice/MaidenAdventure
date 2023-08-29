using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    public bool IsTakePosition { get; private set; } = false;

    private float _timeHealth = 1.8f;

    private void Update()
    {
        if (IsTakePosition == false)
            return;

        _timeHealth -= Time.deltaTime;

        if (_timeHealth <= 0)
        {
            IsTakePosition = false;
            _timeHealth = 1.8f;
        }
    }

    public void SetTruePosition()
    {
        IsTakePosition = true;
    }

    public void SetFalsePosition()
    {
        IsTakePosition = false;
    }
}
