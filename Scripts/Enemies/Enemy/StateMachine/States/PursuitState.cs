using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : MoveState
{
    [SerializeField] private float _coefficientIncreasedSpeed = 4;
   
    private Player _player;
    private EnemyVisibilityRange _enemyVisibility;

    public Player Target => _player;

    private void OnEnable()
    {
        if (_enemyVisibility != null)
            _player = _enemyVisibility.Target;
        EnemyAnimator.SetBool("Run", true);
        TargetPoint = _player.transform.position;
        IsPlayingAnimation = false;
        SetDirection();
        Speed = GetSpeed();
    }

    protected override void Initialize()
    {
        _enemyVisibility = GetComponentInChildren<EnemyVisibilityRange>();
    }

    protected override void CheckTarget()
    {
        TargetPoint = _player.transform.position;
        TryFlip(TargetPoint);
    }
    private float GetSpeed()
    {
        float speed;
        if (LastState is PatrolState || LastState is RestState)
            speed = Enemy.Speed * _coefficientIncreasedSpeed;
        else if (LastState is AttackState attackState)
            speed = attackState.TargetSpeed;
        else
            speed = Enemy.Speed;
        return speed;
    }
}
