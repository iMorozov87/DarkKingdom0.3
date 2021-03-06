using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAfterPursuitTransition : Transition
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
            if (_enemyVisibility.IsTargetDetected == false)
                OnPlayerLosted();
            _enemyVisibility.PlayerLosted += OnPlayerLosted;
        }

    }
    private void OnDisable()
    {
        if (_enemyVisibility != null)
            _enemyVisibility.PlayerLosted -= OnPlayerLosted;
    }

    private void OnPlayerLosted()
    {
        NeedTransite = true;
    }
}
