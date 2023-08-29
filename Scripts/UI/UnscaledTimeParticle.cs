using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class UnscaledTimeParticle : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Time.timeScale < 0.01f)
        {
            _particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
