using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ChangeText : MonoBehaviour
{
    [SerializeField] private DirectionHero _directionHero;
    [SerializeField] private Storage _storage;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private TextMeshProUGUI _textBonusLevel;

    private int _level;
    private float _timeDelay = 0.1f;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.01f);   

    private void OnEnable()
    {
        _directionHero.Reached += SetText;
    }

    private void OnDisable()
    {
        _directionHero.Reached -= SetText;
    }

    private void SetText()
    {        
        if (PlayerPrefs.GetInt(_storage.ControlForChangeText) != 0 == false 
            && (PlayerPrefs.GetInt(_storage.TextLevel) - 1) % 5 == 0)
        {          
            _textLevel.gameObject.SetActive(false);
            _textBonusLevel.gameObject.SetActive(true);
            StartCoroutine(FadeIn(_textBonusLevel));           
        }
        else if (PlayerPrefs.HasKey(_storage.TextLevel))
        {
            _level = PlayerPrefs.GetInt(_storage.TextLevel);             
            Invoke(nameof(ChangeNameLevel), _timeDelay);
            StartCoroutine(FadeIn(_textLevel));            
        }
        else
        {
            _level = PlayerPrefs.GetInt(_storage.TextLevel);
            Invoke(nameof(ChangeNameLevel), _timeDelay);
            StartCoroutine(FadeIn(_textLevel));
        }       
    }

    private IEnumerator FadeIn(TextMeshProUGUI text)
    {
        var color = text.color;     

        for (int i = 0; i < 255; i++)
        {
            color.a = i * 1f / 255f;
            text.color = color;           
            yield return _waitForSeconds;
        }
    }

    private void ChangeNameLevel()
    {
        string tempText = _textLevel.text;
        _textLevel.text = tempText + $" {_level}";
    }
}
