using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnPoint : SpawnPoint
{
    [SerializeField] private EnemiesGroup[] _enemiesGroups;

    private List<Enemy> _enemies = new List<Enemy>();
    private Coroutine _activateAllEnemies;
    private int _enemiesDead = 0;

    public event UnityAction AllDead;

    public override void Init()
    { 
        foreach (var enemiesGroup in _enemiesGroups)
        {
            for (int j = 0; j < enemiesGroup.MaxNumberEnemies; j++)
            {
                Enemy newEnemy = Instantiate(enemiesGroup.EnemyPreabs, transform);
                newEnemy.GetComponent<EnemyParametersSetter>().SetLevel(enemiesGroup.Level);
                newEnemy.Die += AddDiedEnemy;
                _enemies.Add(newEnemy);
            }
        }    

        if(_isLopping)
        _activateAllEnemies = StartCoroutine(ActivateAllEnemies());
    }

    private void AddDiedEnemy()
    {
        _enemiesDead++;
        if(_enemiesDead >= _enemies.Count)
        {
            _enemiesDead = 0;
            AllDead?.Invoke();
        }
    }

    public override void Init(Quest quest)
    {
        int numberEnemies = quest.NumberCondition - quest.NumberTakenCondition;
        foreach (var enemiesGroup in _enemiesGroups)
        {
            for (int j = 0; j < enemiesGroup.MaxNumberEnemies; j++)
            {
                Enemy newEnemy = Instantiate(enemiesGroup.EnemyPreabs, transform.localPosition, Quaternion.identity);
          
                newEnemy.GetComponent<EnemyParametersSetter>().SetLevel(enemiesGroup.Level);
                QuestObject questObject = newEnemy.gameObject.AddComponent<QuestObject>();
                questObject.SetQuest(quest);
                newEnemy.Die += AddDiedEnemy;
                _enemies.Add(newEnemy);
            }
        }
    }

    private IEnumerator ActivateAllEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToActivation);
            ActivateEnemies();
        }
    }

    private void ActivateEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.gameObject.SetActive(true);           
        }
    }

    [System.Serializable]
    public class EnemiesGroup
    {
        public Enemy EnemyPreabs;
        public int Level=1;
        public int MaxNumberEnemies;
    }
}
