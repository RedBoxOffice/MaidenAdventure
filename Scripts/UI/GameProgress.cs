using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private Inventar _inventar;
    [SerializeField] private Congratulate _congratulate;

    private const float DelayTimeForGameProgress = 0.1f;
    private const float DelayTimeForDeactivate = 2.5f;
    private float _elapsed = 0;
    private ParticleSystem _particleSystem;
    private WaitForSecondsRealtime _waitForSecondsRealtime = new WaitForSecondsRealtime(DelayTimeForGameProgress);
    private WaitForSecondsRealtime _waitForSecondsForDeactivate = new WaitForSecondsRealtime(DelayTimeForDeactivate);

    private void Awake()
    {       
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_inventar != null)
        {
            _inventar.RewardMoney += SetProgress;
        }   
        else if (_congratulate != null)
        {
            _congratulate.AddReward += SetProgress;
        }
    }

    private void OnDisable()
    {
        if (_inventar != null)
        {
            _inventar.RewardMoney -= SetProgress;
        } 
        else if (_congratulate != null)
        {
            _congratulate.AddReward -= SetProgress;
        }
    }

    private void SetProgress(int newMoney, int currentMoney)
    {      
        float normalizedValue = currentMoney / newMoney;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);        
        StartCoroutine(LerpValue(currentMoney, newMoney + currentMoney, duration));       
    }

    private IEnumerator LerpValue(float startValue, float endValue, float duration)
    {
        while (_elapsed < duration)
        {
            float nextValue;                   
            nextValue = Mathf.Lerp(startValue, endValue, _elapsed / duration);           
            SetTextValue(nextValue);         
            _elapsed += 0.1f;
            yield return _waitForSecondsRealtime;
        }

        _elapsed = 0;
        SetTextValue(endValue);
        _particleSystem.gameObject.SetActive(true);
        StartCoroutine(DeactivatePanel());
    }      

    private void SetTextValue(float value)
    {
        value = Mathf.RoundToInt(value);
        _text.text = value.ToString();
    }

    private IEnumerator DeactivatePanel()
    {
        yield return _waitForSecondsForDeactivate;

        if (_inventar != null)
        {
            _particleSystem.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }       
    }
}
