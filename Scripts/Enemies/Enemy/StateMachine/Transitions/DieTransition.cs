using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieTransition :Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _enemy.Die += OnDie;
    }

    private void OnDisable()
    {
        _enemy.Die -= OnDie;
    }

    private void OnDie()
    {
        NeedTransite = true;
    }
}
