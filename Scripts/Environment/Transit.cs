using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LeaderboardGame))]
public class Transit : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators = new List<Animator>(2);
    [SerializeField] private Wallet _wallet;

    private LeaderboardGame _leaderboardGame;
    private float _delayTimeForAddPlayer = 1f;
    private float _delayTimeForLoadNextLevel = 4f;
   

    private void Start()
    {
        _leaderboardGame = GetComponent<LeaderboardGame>();        

        for (int i = 0; i < _animators.Count; i++)
        {
            _animators[i].enabled = false;
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _animators.Count; i++)
        {
            _animators[i].enabled = true;
        }

        Invoke(nameof(AddMoneyForPlayer), _delayTimeForAddPlayer);
        Invoke(nameof(ExitLevel), _delayTimeForLoadNextLevel);
    } 

    private void AddMoneyForPlayer()
    {
        _leaderboardGame.AddPlayer(_wallet.Money);
    }
    
    private void ExitLevel()
    {
        SceneManager.LoadScene(2);
    }
}
