using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Storage _storage;   

    public readonly List<int> _activateScenes = new List<int>();  

    private void Start()
    {       
        for (int i = 3; i < PlayerPrefs.GetInt(_storage.ProgressScene) + 1; i++)
        {
            _activateScenes.Add(i);
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        for (int i = 0; i < _activateScenes.Count; i++)
        {
            _buttons[i].interactable = true;

            if (i >= 5 && i % 5 == 0)
            {
                if (PlayerPrefs.GetInt(_storage.BoolBonusLevel + (i + 3)) != 0 == true)
                {
                    _buttons[i].interactable = true;
                }
                else
                {
                    _buttons[i].interactable = false;
                }
            }
        }       
    }

    public void LoadScene(int levelIndex)
    {
        PlayerPrefs.SetInt($"LevelIndex {levelIndex}", levelIndex);
        SceneManager.LoadScene(levelIndex);
    }
}
