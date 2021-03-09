using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyAttacker
{
    [SerializeField] private FireBall _fireBallTemplate;
    [SerializeField] private Transform _shotPoint;

    //public override void AttackTarget(Player player)
    //{

    //    int demage = _enemy.Demage;
    //    _animator.SetTrigger("Attack");
    //    FireBall newFireBall = Instantiate(_fireBallTemplate, _shotPoint.position, Quaternion.identity);
    //    newFireBall.SetDemage(_enemy.Demage);
    //    newFireBall.GetComponent<FireBallMover>().SetTarget(player.transform.position);

    //    _enemyMover.SetSpeed(_speedAfterAttack);
    //}

    //protected override float SetSpeedAfterAttack()
    //{
    //    return _enemyMover.BaseSpeed * 0.5F;
    //}
}
