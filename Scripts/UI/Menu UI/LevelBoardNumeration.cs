using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelBoardNumeration : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _text;
   
    public void ChangeText()
    {
        string tempText;

        for (int i = 0; i < _text.Count; i++)
        {
            tempText = _text[i].text;
            _text[i].text = tempText + $" {i + 1}";
        }
    }
}
