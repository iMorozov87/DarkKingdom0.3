using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private EnemyAttackStarter _attackStarter;

    private void Awake()
    {
        _attackStarter = GetComponentInChildren<EnemyAttackStarter>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _attackStarter.TargetReached += OnTargetReached;
    }

    private void OnDisable()
    {
        _attackStarter.TargetReached -= OnTargetReached;
    }

    private void OnTargetReached()
    {
        NeedTransite = true;
    }
}
