using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowClue : MonoBehaviour
{   
    public void SetText(Clue clue)
    {
        TextMeshProUGUI _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.text = clue.WordTMP.text;
    }
}
