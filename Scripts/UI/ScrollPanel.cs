using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour
{
    [SerializeField] private Inventar _inventar;

    private const float DelayTime = 5f;
    private const float DelayTimeForButton = 7f;
    private ShowClue _showClue;
    private WaitForSecondsRealtime _secondsRealtime = new WaitForSecondsRealtime(DelayTime);
    private WaitForSecondsRealtime _delayButton = new WaitForSecondsRealtime(DelayTimeForButton);
    private Button _button;

    private void Awake()
    {
        _showClue = GetComponentInChildren<ShowClue>();
        _button = GetComponentInChildren<Button>();
        _showClue.gameObject.SetActive(false);
        _button.gameObject.SetActive(false);
    }   

    private void OnEnable()
    {
        _inventar.RewardClue += ActivateScrollReward;
    }

    private void ActivateScrollReward(Clue clue)
    {
        StartCoroutine(ActivatePanelScrollReward(clue));
        StartCoroutine(ActivateButtonForContinueGame());
    }
    
    private IEnumerator ActivatePanelScrollReward(Clue clue)
    {
        yield return _secondsRealtime;
        _showClue.gameObject.SetActive(true);
        _showClue.SetText(clue);      
    }

    private IEnumerator ActivateButtonForContinueGame()
    {
        yield return _delayButton;
        _button.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _inventar.RewardClue -= ActivateScrollReward;       
    }
}
