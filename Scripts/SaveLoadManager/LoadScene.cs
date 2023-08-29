using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private SavePointPlayer _saveLoadManager;

    private void Start()
    {
        Invoke(nameof(LoadSaveData), 0f);        
    }

    private void LoadSaveData()
    {
        _saveLoadManager.LoadGame();
        _saveLoadManager.SaveGame();       
    }  
}
