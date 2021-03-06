using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitTransition : Transition
{
    private EnemyVisibilityRange _enemyVisibility;

    private void Awake()
    {
        _enemyVisibility = GetComponentInChildren<EnemyVisibilityRange>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        if (_enemyVisibility != null)
        {
            _enemyVisibility.PlayerDetected += OnPlayerDetected;
            if (_enemyVisibility.IsTargetDetected)
                OnPlayerDetected();
        }
    }

    private void OnDisable()
    {
        if (_enemyVisibility != null)
            _enemyVisibility.PlayerDetected -= OnPlayerDetected;
    }

    private void OnPlayerDetected()
    {
        NeedTransite = true;
    }
}
