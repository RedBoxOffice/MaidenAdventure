using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusReward : MonoBehaviour
{
    protected UIRandomGenerator _randomGenerator;
    protected float _timeHealth = 1f;
    protected int _defaultReward = 8;

    private void Start()
    {
        _randomGenerator = FindObjectOfType<UIRandomGenerator>();
    }

    private void Update()
    {
        if (gameObject.activeSelf == false)
            return;
        else
            _timeHealth -= Time.deltaTime;

        if (_timeHealth <= 0)
        {
            _timeHealth = 1f;
            gameObject.SetActive(false);
        }
    }
}
