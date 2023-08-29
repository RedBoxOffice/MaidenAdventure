using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UITimer : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _timer.RealTime += SetTextTime;
    }

    private void SetTextTime(float minutes, float seconds)
    {
        _text.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void OnDisable()
    {
        _timer.RealTime -= SetTextTime;
    }
}
