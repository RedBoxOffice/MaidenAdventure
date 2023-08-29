using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bomb : BonusReward, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        _randomGenerator.PutAwayMoney(_defaultReward);
        _timeHealth = 1f;
        gameObject.SetActive(false);
    }
}
