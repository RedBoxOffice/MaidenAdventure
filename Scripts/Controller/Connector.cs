using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Connector : MonoBehaviour
{
    [SerializeField] private Inventar _inventar;
    [SerializeField] private ParticleSystem _clueLight;
    [SerializeField] private ParticleSystem _boomClue;
    [SerializeField] private Timer _timer;

    public event UnityAction Linking;
    private BoxCollider _boxCollider;

    private void Start()
    {        
        _boxCollider = GetComponent<BoxCollider>();        
    }

    private void OnEnable()
    {
        _timer.OverTime += SwitchParticleSystem;
    }

    private void OnDisable()
    {
        _timer.OverTime -= SwitchParticleSystem;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Wire lighting))
        {
            if (lighting.BatteryComponent == true && _timer.TimeLeft > 0)
            {              
                _boxCollider.enabled = false;
                Linking?.Invoke();
                _inventar.AcceptReward();
                _timer.CancelTime();
            }           
        }       
    } 
    
    private void SwitchParticleSystem()
    {
        _clueLight.gameObject.SetActive(false);
        _boomClue.gameObject.SetActive(true);
    }
}
