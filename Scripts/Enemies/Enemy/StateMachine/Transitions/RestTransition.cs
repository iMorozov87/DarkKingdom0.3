using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PatrolState))]
public class RestTransition : Transition
{
    private PatrolState _patrolState;

    private void Awake()
    {
        _patrolState = GetComponent<PatrolState>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _patrolState.TargetReachad += TryRest;
    }

    private void OnDisable()
    {
        _patrolState.TargetReachad -= TryRest;
    }

    private void TryRest()
    {
        float minProbabilityValue = 0;
        float maxProbabilityValue = 10;
        float borderRestValue = 5;
        float randomValue = Random.Range(minProbabilityValue, maxProbabilityValue);

        if (randomValue <= borderRestValue)
        {
            NeedTransite = true;
        }
        else
        {
            NeedTransite = false;
        }
    }
}