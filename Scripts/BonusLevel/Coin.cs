using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : BonusReward, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {        
        _randomGenerator.AddMoney(_defaultReward);
        _timeHealth = 1f;
        gameObject.SetActive(false);
    }
}
