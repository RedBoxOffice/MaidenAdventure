using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Bag))]
public class Inventar : MonoBehaviour
{
    [SerializeField] private Connector _connector;
    [SerializeField] private Clue _clue;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _defaultCountMoney = 40;

    public event UnityAction<int, int> RewardMoney;
    public event UnityAction<Clue> RewardClue;
    private Wallet _wallet;
    private Bag _bag;
    private float _delayTimeForDoneAcceptMoney = 5f;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
        _bag = GetComponent<Bag>();
    }

    public void AcceptReward()
    {
        AcceptMoney(_timer);        
        _bag.AddClue(_clue);
        RewardClue?.Invoke(_clue);        
        _timer.gameObject.SetActive(false);
    }  

    public void DefaultAcceptReward()
    {
        Invoke(nameof(AcceptMoney), _delayTimeForDoneAcceptMoney);    
    }

    private void AcceptMoney()
    {       
        RewardMoney?.Invoke(_defaultCountMoney, _wallet.Money);
        _wallet.AddMoney(_defaultCountMoney);
    }

    private void AcceptMoney(Timer timer)
    {             
        RewardMoney?.Invoke(Mathf.RoundToInt(timer.TimeLeft), _wallet.Money);
        _wallet.AddMoney(Mathf.RoundToInt(timer.TimeLeft));        
    }    
}
