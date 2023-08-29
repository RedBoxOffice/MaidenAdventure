using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private Clue _clue;

    public void AddClue(Clue clue)
    {
        _clue = clue;
    }
    
    public TextMeshPro GetWord()
    {
        if (_clue != null)
        {          
            return _clue.WordTMP;
        }
        else
        {
            return null;
        }        
    }
}
