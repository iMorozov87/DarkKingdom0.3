using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackState : State
{
    [SerializeField] protected Enemy Enemy;

    protected EnemyAttackStarter _attackStarter;    
    protected Animator Animator;
    protected float SpeedAfterAttack;

    public float TargetSpeed => SpeedAfterAttack;

    protected void Awake()
    {     
        Animator = Enemy.GetComponent<Animator>();
        _attackStarter = GetComponentInChildren<EnemyAttackStarter>();
        SpeedAfterAttack = SetSpeedAfterAttack();
    }

    protected void OnEnable()
    {
        AttackTarget(_attackStarter.Target);
    }

    protected abstract void AttackTarget(Player player);

    protected abstract float SetSpeedAfterAttack();
}
