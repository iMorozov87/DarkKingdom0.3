using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyParametersSetter : MonoBehaviour
{
    [SerializeField] private EnemyParametersInt _maxHealth;
    [SerializeField] private EnemyParametersInt _demage;
    [SerializeField] private EnemyParametersInt _rewardExperience;
    [SerializeField] private EnemyParametersInt _rewardMoney;

    private Enemy _enemy;

    public EnemyParametersInt MaxHealth => _maxHealth;
    public EnemyParametersInt Demage => _demage;
    public EnemyParametersInt RewardExpereence => _rewardExperience;
    public EnemyParametersInt RewardMoney => _rewardMoney;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void SetLevel(int level)
    {
        _maxHealth.Level = level;
        _maxHealth.IncreaseLevel();
        _demage.Level = level;
        _demage.IncreaseLevel();
        _rewardExperience.Level = level;
        _rewardExperience.IncreaseLevel();
        _rewardMoney.Level = level;
        _rewardMoney.IncreaseLevel();
        _enemy.SetEnemy(_maxHealth.CurrentValue, _demage.CurrentValue, _rewardExperience.CurrentValue, _rewardMoney.CurrentValue,  level);
    }
}
