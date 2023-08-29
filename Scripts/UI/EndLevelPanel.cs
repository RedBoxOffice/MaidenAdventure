using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelPanel : MonoBehaviour
{
    private Button _button;
    private float _delayTimeForActivateButton = 1f;

    private void Start()
    {
        _button = GetComponentInChildren<Button>();
        _button.gameObject.SetActive(false);
        DelayTime();
    }

    private void DelayTime()
    {
        Invoke(nameof(ActivateButton), _delayTimeForActivateButton);
    }

    private void ActivateButton()
    {
        _button.gameObject.SetActive(true);
    }
}
