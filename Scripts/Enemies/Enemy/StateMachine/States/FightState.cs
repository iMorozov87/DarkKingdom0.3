using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : AttackState
{
    protected override void AttackTarget(Player player)
    {
        int demage = Enemy.Demage;
        Animator.SetTrigger("Attack");
        player.ApplyDemage(demage); 
    }

    protected override float SetSpeedAfterAttack()
    {
        return Enemy.Speed;
    }
}
