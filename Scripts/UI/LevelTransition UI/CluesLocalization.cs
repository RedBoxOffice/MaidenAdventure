using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(LeanLocalizedText))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class CluesLocalization : MonoBehaviour
{
    private LeanLocalizedText _localizedText;
    private TextMeshProUGUI _textClues;
    private float _delayTimeForSetText = 0.1f;

    private void Start()
    {
        _localizedText = GetComponent<LeanLocalizedText>();
        _textClues = GetComponent<TextMeshProUGUI>();
        Invoke(nameof(SetText), _delayTimeForSetText);
    }

    private void SetText()
    {       
        if (_textClues.text != "")
        {            
            _localizedText.enabled = true;
        }
        else
        {
            _localizedText.enabled = false;
        }        
    }
}
