using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class RestState : State
{
    protected Rigidbody2D _rigidbody2D;
    protected Animator _enemyAnimator;

    protected void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    protected void OnEnable()
    {
        _enemyAnimator.SetBool("Run", false);
        _rigidbody2D.velocity = Vector2.zero;
    }
}
