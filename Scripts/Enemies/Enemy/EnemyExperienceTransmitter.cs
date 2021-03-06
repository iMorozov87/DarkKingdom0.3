using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(PursuitState))]

public class EnemyExperienceTransmitter : MonoBehaviour
{
    private Enemy _enemy;
    private PursuitState _pursuitState;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _pursuitState = GetComponent<PursuitState>();     
    }

    private void OnEnable()
    {
        _enemy.Die += ShareExperience;
    }

    private void OnDisable()
    {
        _enemy.Die -= ShareExperience;
    }

    private void ShareExperience()
    {       
        Player player = _pursuitState.Target;
        player.AddExperience(_enemy.RewardExperience);
    }
}
