using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatorBonusSpawnPoint : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private int Shance = 100;
    [SerializeField] private EnemySpawnPoint _enemySpawnPoint;
    [SerializeField] private ItemSpawnPoint _itemSpawnPoint;

    private void OnEnable()
    {
        _enemySpawnPoint.AllDead += CreateBonus;
    }

    private void OnDisable()
    {
        _enemySpawnPoint.AllDead -= CreateBonus;
    }

    private void CreateBonus()
    {
        _itemSpawnPoint.Init();
    }
}
