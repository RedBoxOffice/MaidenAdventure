using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuDirection : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);        
    }
}
