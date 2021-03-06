using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{    
    [SerializeField] private int _health;
    [SerializeField] private int _demage = 3;
    [SerializeField] private float _speed = 2.0F;
    [SerializeField] private int _rewardExperience;
    [SerializeField] private int _rewardMoney;
    [SerializeField] private DeadEnemy _deadEnemyPrefab;
    [SerializeField] private GameObject _effectBloodTemplate;
    [SerializeField] private Coints _moneyTemplate;

    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    private EnemyMover _enemyMover;
    private int _level;
    //private bool _isAlive;
    //private bool _isOnDied = false;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public int Level => _level;
    public int Health => _health;
    public int Demage => _demage;
    public float Speed => _speed;

    //public bool IsAlive => _isAlive;
    public int RewardExperience => _rewardExperience;
    public int RewardMoney => _rewardMoney;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Die;

    public void SetEnemy(int health, int demage, int rewardExperience, int rewardMoney, int level)
    {
        _health = health;
        _demage = demage;
        _rewardExperience = rewardExperience;
        _rewardMoney = rewardMoney;
        _level = level;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyMover = GetComponent<EnemyMover>();
        _audioSource = GetComponent<AudioSource>();
        _speed = GetRandomSpeed(_speed);        
    }

    //private void OnEnable()
    //{
    //    _isAlive = true;
    //}

    //private void OnDisable()
    //{
    //    _isAlive = false;
    //}

    public void ApplyDemage(int demage, Vector3 playerPosition)
    {
        _health -= demage;
        if (_health <= 0)
        {
            Die?.Invoke();
        }
        Instantiate(_effectBloodTemplate, transform);
        _audioSource.Play();
        HealthChanged?.Invoke(_health);        
    }

    public void OnDied()
    {
        if (_health <= 0)
        {
            //_isOnDied = true;
            DeadEnemy deadEnemy = Instantiate(_deadEnemyPrefab, transform.position, Quaternion.identity);
            deadEnemy.Init(transform.localScale);
            Instantiate(_moneyTemplate, transform.position + new Vector3(UnityEngine.Random.Range(-0.5F, 0.5F), UnityEngine.Random.Range(-0.5F, 0.5F)), Quaternion.identity);
            Instantiate(_effectBloodTemplate, transform);

            if (gameObject.TryGetComponent<QuestObject>(out QuestObject questObject))
            {
                questObject.DoneCondition();
            }
            gameObject.SetActive(false);
        }
    }

    private float GetRandomSpeed(float baseSpeed)
    {
        float minСoefficienSpeed = 0.85F;
        float maxСoefficienSpeed = 1.08F;
        float speed = baseSpeed * UnityEngine.Random.Range(minСoefficienSpeed, maxСoefficienSpeed);
        return speed;
    }
}
