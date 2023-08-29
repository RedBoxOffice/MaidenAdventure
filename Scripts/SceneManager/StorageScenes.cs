using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Build.Content;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorageScenes : MonoBehaviour
{
    [SerializeField] private Action _action;

    public readonly List<int> _countScene = new List<int>();

    private void Start()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            _countScene.Add(i);
        }
    }
}
