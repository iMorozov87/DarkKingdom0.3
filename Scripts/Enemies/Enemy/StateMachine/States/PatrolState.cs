using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatrolState : MoveState
{
    [SerializeField] private float _radiusMovement;

    private Vector2 _centrMovementPoint;
    private Vector2[] _listRandomTargetPoint;
    private int _numberCurrentTargetPoint = 0;

    public event UnityAction TargetReachad;

    protected override void Initialize()
    {
        _centrMovementPoint = transform.position;
        _listRandomTargetPoint = CreateListRandomPoint();
        TargetPoint = _listRandomTargetPoint[_numberCurrentTargetPoint];
    }

    protected override void CheckTarget()
    {
        if (transform.position == TargetPoint)
        {
            TargetReachad?.Invoke();
            TargetPoint = GetTargetPoint();
            TryFlip(TargetPoint);
        }
    }

    private void OnEnable()
    {
        TargetReachad?.Invoke();
        IsPlayingAnimation = false;
        Speed = Enemy.Speed;
        SetDirection();
    }
    private Vector3 GetTargetPoint()
    {
        _numberCurrentTargetPoint++;
        if (_numberCurrentTargetPoint == _listRandomTargetPoint.Length)
        {
            _numberCurrentTargetPoint = 0;
        }
        return _listRandomTargetPoint[_numberCurrentTargetPoint];
    }

    private Vector2[] CreateListRandomPoint()
    {
        int numderPoints = 6;
        Vector2[] newListTargetPoint = new Vector2[numderPoints];
        for (int i = 0; i < numderPoints; i++)
        {
            newListTargetPoint[i] = _centrMovementPoint + UnityEngine.Random.insideUnitCircle * _radiusMovement;

            if (i > 0 && newListTargetPoint[i] == newListTargetPoint[i - 1])
                i--;
        }
        return newListTargetPoint;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusMovement);
    }
}
