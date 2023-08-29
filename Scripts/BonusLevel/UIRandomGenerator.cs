using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRandomGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMoney;
    [SerializeField] private Congratulate _congratulate;

    private const float _timeForWaitSeconds = 0.3f;
    private PointSpawn[] _spawners;
    private BonusReward[] _reward;
    private float _time = 10;
    private float _delayTimeForStatsBonusLevel = 2f;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_timeForWaitSeconds);
    
    public int DefaultMoney { get; private set; } = 0;   
    public int TempMoney { get; private set; }

    private void Start()
    {       
        _textMoney.text = DefaultMoney.ToString();
        _spawners = FindObjectsOfType<PointSpawn>();
        _reward = GetComponentsInChildren<BonusReward>();        

        for (int i = 0; i < _reward.Length; i++)
        {
            _reward[i].gameObject.SetActive(false);
        }

        InitializeCoroutine();
    }

    private void Update()
    {
        if (_time <= 0)
            return;

       _time -= Time.deltaTime;
    }

    public void AddMoney(int reward)
    {
        TempMoney += reward;
        SetTextReward(TempMoney);
    }

    public void PutAwayMoney(int reward)
    {
        TempMoney -= reward;
        SetTextReward(TempMoney);
    }
   
    private void InitializeCoroutine()
    {
       StartCoroutine(ShowRandomCoin());
    }

    private IEnumerator ShowRandomCoin()
    {
        while(_time > 0)
        {
            int randomCoin = Random.Range(0, _reward.Length);

            while (_reward[randomCoin].gameObject.activeSelf == true)
            {
                randomCoin = Random.Range(0, _reward.Length);
            }

            int randomPositionCoin = Random.Range(0, _spawners.Length);

            while (_spawners[randomPositionCoin].IsTakePosition == true)
            {
                randomPositionCoin = Random.Range(0, _spawners.Length);
            }

            _spawners[randomPositionCoin].SetTruePosition();
            _reward[randomCoin].gameObject.transform.position = _spawners[randomPositionCoin].gameObject.transform.position;            
            _reward[randomCoin].gameObject.SetActive(true);
            yield return _waitForSeconds;
        }

        _textMoney.gameObject.SetActive(false);
        _congratulate.gameObject.SetActive(true);
        Invoke(nameof(StartScriptStatsBonusLevel), _delayTimeForStatsBonusLevel);
    }

    private void SetTextReward(int reward)
    {
        _textMoney.text = reward.ToString();
    }

    private void StartScriptStatsBonusLevel()
    {
        _congratulate.ActivateStatsBonusLevel();
    }
}
