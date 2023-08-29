using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Wire : MonoBehaviour
{
    private ParticleSystem _lighting;
    private bool _isBatteryComponent = false;

    public bool BatteryComponent => _isBatteryComponent;

    private void Start()
    {
        _lighting = GetComponent<ParticleSystem>();
        _lighting.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Battery battery))
        {
            _lighting.Play();
            _isBatteryComponent = true;
        }
        else if (other.TryGetComponent(out Wire lighting))
        {
            if (lighting.BatteryComponent == true)
            {
                _isBatteryComponent = true;
                _lighting.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isBatteryComponent = false;
        _lighting.Stop();
    }       
}
