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
                Enemy newEnemy = CreateEnemy(enemiesGroup.EnemyPrefabs);                
                _enemies.Add(newEnemy);
            }
        }    

        if(_isLopping)
        _activateAllEnemies = StartCoroutine(ActivateAllEnemies());
    }

    public override void Init(Quest quest)
    {
        int numberEnemies = quest.NumberCondition - quest.NumberTakenCondition;
        foreach (var enemiesGroup in _enemiesGroups)
        {
            for (int j = 0; j < enemiesGroup.MaxNumberEnemies; j++)
            {
                Enemy newEnemy = CreateEnemy(enemiesGroup.EnemyPrefabs);               
                QuestObject questObject = newEnemy.gameObject.AddComponent<QuestObject>();
                questObject.SetQuest(quest);
                _enemies.Add(newEnemy);
            }
        }
    }

    private Enemy CreateEnemy(Enemy enemyTemplate)
    {
        Enemy enemy = Instantiate(enemyTemplate, transform.localPosition, Quaternion.identity);
        enemy.GetComponent<EnemyParametersSetter>().SetLevel(enemiesGroup.Level);
        enemy.Die += AddDiedEnemy;
        return enemy;
    }

    private void AddDiedEnemy(Enemy enemy)
    {
        _enemiesDead++;
        enemy.Die -= AddDiedEnemy;
        if(_enemiesDead >= _enemies.Count)
        {
            _enemiesDead = 0;
            AllDead?.Invoke();
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
        public Enemy EnemyPrefabs;
        public int Level=1;
        public int MaxNumberEnemies;
    }
}
