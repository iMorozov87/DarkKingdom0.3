using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
[RequireComponent(typeof(Rigidbody2D))]
public class DeathState : State
{
    [SerializeField] private float _durationStun = 0.1f;

    private Animator _animator;
    private float _durationAnimation;
    private Enemy _enemy;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        _durationAnimation = stateInfo.length;
        _enemy = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger("Die");
        StartCoroutine(CountDownTimeToDeath(_durationStun,_durationAnimation));
    }

    private IEnumerator CountDownTimeToDeath(float durationStun, float durationAnimation)
    {
        float restTime = durationAnimation - durationStun;
        yield return new WaitForSeconds(durationStun);
        _rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(restTime);
        _enemy.OnDied();
    }
}
