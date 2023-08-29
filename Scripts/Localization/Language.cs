using Agava.YandexGames;
using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeanLocalization))]
public class Language : MonoBehaviour
{
    private LeanLocalization _leanLocalization;
    private string _russianRegion = "ru";
    private string _englishRegion = "en";
    private string _turkishRegion = "tr";
    private string _region;
    private string _russian = "Russian";
    private string _english = "English";
    private string _turkish = "Turkish";
    private string _saveLocalization = "SaveLocalization";

    private void Start()
    {
        _leanLocalization = GetComponent<LeanLocalization>();

        if (PlayerPrefs.HasKey(_saveLocalization))
        {
            _leanLocalization.CurrentLanguage = PlayerPrefs.GetString(_saveLocalization);
        }
        else
        {
            _region = YandexGamesSdk.Environment.i18n.lang;
            ChooseLocalization();
        }
    }

    public void ChangeLocalizationOnRussian()
    {
        _leanLocalization.CurrentLanguage = _russian;
        PlayerPrefs.SetString(_saveLocalization, _leanLocalization.CurrentLanguage);
    }

    public void ChangeLocalizationOnEnglish()
    {
        _leanLocalization.CurrentLanguage = _english;
        PlayerPrefs.SetString(_saveLocalization, _leanLocalization.CurrentLanguage);
    }

    public void ChangeLocalizationOnTurkish()
    {
        _leanLocalization.CurrentLanguage = _turkish;
        PlayerPrefs.SetString(_saveLocalization, _leanLocalization.CurrentLanguage);
    }

    private void ChooseLocalization()
    {
        if (_region == _russianRegion)
        {
            _leanLocalization.CurrentLanguage = _russian; 
        }
        else if (_region == _englishRegion)
        {
            _leanLocalization.CurrentLanguage = _english;
        }
        else if (_region == _turkishRegion)
        {
            _leanLocalization.CurrentLanguage = _turkish;
        }

        PlayerPrefs.SetString(_saveLocalization, _leanLocalization.CurrentLanguage);
    }
}
