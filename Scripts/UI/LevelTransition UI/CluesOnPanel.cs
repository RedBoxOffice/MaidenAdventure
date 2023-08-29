using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CluesOnPanel : MonoBehaviour
{
    [SerializeField] private Storage _storage;

    private List<TextMeshProUGUI> _textClues = new List<TextMeshProUGUI>();    
    private int _amountWordsOnPanel = 15;
    private bool _isReachedBoundsStartArray = false;

    private void Start()
    {
        _textClues = GetComponentsInChildren<TextMeshProUGUI>().ToList();

        for (int i = 0; i < _storage.Clues.Count; i++)
        {
            _textClues[i].text = _storage.Clues[i];
        }

        for (int i = _amountWordsOnPanel; i < _textClues.Count; i++)
        {
            _textClues[i].gameObject.SetActive(false);
        }
    }

    public void ActivateCluesOnNextPanel()
    {
        for (int i = 0; i < _textClues.Count; i++)
        {          
            if (_textClues[i].gameObject.activeSelf == true)
            {
                _textClues[i].gameObject.SetActive(false);                

                if (_isReachedBoundsStartArray == false)
                {
                    _isReachedBoundsStartArray = true;                   
                }                    
            }
            else if (_textClues[i].gameObject.activeSelf == false && _isReachedBoundsStartArray == true)
            {
                _textClues[i].gameObject.SetActive(true);

                if ((i + 1) % 15 == 0)                
                    break; 
            }           
        }
    }

    public void ActivateDefaultStateText()
    {       
        for (int i = 0; i < _amountWordsOnPanel; i++)
        {
            _textClues[i].gameObject.SetActive(true);
        }

        for (int i = _amountWordsOnPanel; i < _textClues.Count; i++)
        {
            _textClues[i].gameObject.SetActive(false);
        }
    }

    public void ActivateCluesOnBackPanel()
    {
        for (int i = _textClues.Count - 1; i >= 0; i--)
        {
            if (_textClues[i].gameObject.activeSelf == true)
            {
                _textClues[i].gameObject.SetActive(false);

                if (_isReachedBoundsStartArray == false)
                {
                    _isReachedBoundsStartArray = true;
                }
            }
            else if (_textClues[i].gameObject.activeSelf == false && _isReachedBoundsStartArray == true)
            {
                _textClues[i].gameObject.SetActive(true);

                if ((i) % 15 == 0)
                    break;
            }
        }
    }

    public void RewriteArray()
    {
        for (int i = 0; i < _storage.Clues.Count; i++)
        {
            _textClues[i].text = _storage.Clues[i];
        }
       
        ActivateDefaultStateText();
    }
}
