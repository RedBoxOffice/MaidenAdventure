using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class Clue : MonoBehaviour
{   
    private TextMeshPro _wordTMP;

    private void Start()
    {
        _wordTMP = GetComponent<TextMeshPro>();
    }

    public TextMeshPro WordTMP => _wordTMP;   
}
