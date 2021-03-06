using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StunState: State
{
    [SerializeField] private float _duration = 0.1f;

    private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyAnimator.SetBool("Run", false);      
    }
}
