using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Storage _storage;

    public void SetText()
    {
        _text.text = _storage.StaticPlayerMoney.ToString();
    }
}
