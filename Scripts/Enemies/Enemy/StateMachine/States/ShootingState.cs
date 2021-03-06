using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : AttackState
{
    [SerializeField] private FireBall _fireBallTemplate;
    [SerializeField] private Transform _shotPoint;

    protected override void AttackTarget(Player player)
    {
        int demage = Enemy.Demage;
        Animator.SetTrigger("Attack");
        FireBall newFireBall = Instantiate(_fireBallTemplate, _shotPoint.position, Quaternion.identity);
        newFireBall.SetDemage(Enemy.Demage);
        newFireBall.GetComponent<FireBallMover>().SetTarget(player.transform.position);
    }

    protected override float SetSpeedAfterAttack()
    {
        float rateChangeSpeed = 0.5F;
        return Enemy.Speed * rateChangeSpeed;
    }
}
