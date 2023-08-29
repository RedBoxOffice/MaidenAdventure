using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Storage _storage;

    private int _money;   
    
    public int Money => _money;

    private void Start()
    {
        _money = _storage.StaticPlayerMoney;
    }

    public void AddMoney(int money)
    {
        _money += money;
    }   
}
