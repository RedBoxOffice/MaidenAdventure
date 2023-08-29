using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnTerrain : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointRespawn pointRespawn))
        {
            transform.position = new Vector3(_startPoint.position.x, transform.position.y, transform.position.z);
        }
    }
}
