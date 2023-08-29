using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Congratulate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private Storage _storage;  
    [SerializeField] private TextMeshProUGUI _newMoneyText;
    [SerializeField] private UIRandomGenerator _randomGenerator;
    [SerializeField] private Image _imagePanelOfCongratulate;

    public event UnityAction <int,int> AddReward;
    private float _timeOfDelay = 4f;

    private void Start()
    {
        _moneyText.text = _storage.StaticPlayerMoney.ToString();
    }

    public void ActivateStatsBonusLevel()
    {
        _moneyText.gameObject.SetActive(true);       
        _newMoneyText.text = _randomGenerator.TempMoney.ToString();
        AddReward?.Invoke(_randomGenerator.TempMoney, _storage.StaticPlayerMoney);
        _storage.SaveDataForSuccessBonusLevel();
        Invoke(nameof(ActivateLastPanel), _timeOfDelay);        
    }

    private void ActivateLastPanel()
    {
        _moneyText.gameObject.SetActive(false);
        _imagePanelOfCongratulate.gameObject.SetActive(true);
    }
}
