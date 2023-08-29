using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCube : MonoBehaviour
{
    private float _distanceDelta = 0.1f;    

    public void MoveOnCubePosition(Vector3 vector3)
    {        
        transform.position = Vector3.MoveTowards(transform.position, vector3, _distanceDelta);
    }
}
