using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ISavable, ILoadable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _demage = 1;
    [SerializeField] private int _maxExperience = 30;
    [SerializeField] private int _money;
    [SerializeField] private SwordHitter _swordHitter;
    [SerializeField] private GameObject _effectBloodTemplate;

    private int _health;
    private int _experience = 0;

    public int Health => _health;
    public int Level => _level;
    public int Demage => _demage;
    public int MaxExperience => _maxExperience;
    public int Money => _money;
    public int Experience => _experience;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MaxHealthChanged;
    public event UnityAction<int, int> ExperienceChanged;
    public event UnityAction LevelUpped;

    private void Awake()
    {
        gameObject.transform.SetParent(null);
    }

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
        ExperienceChanged(_experience, _maxExperience);
    }

    public void ApplyDemage(int demage)
    {
        Instantiate(_effectBloodTemplate, transform);
        _health -= demage;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void AddExperience(int rewardExperience)
    {
        _experience += rewardExperience;
        TryLevelUp();
        ExperienceChanged?.Invoke(_experience, _maxExperience);
    }

    private void TryLevelUp()
    {
        if (_experience >= _maxExperience)
        {
            _experience -= MaxExperience;
            _health = _maxHealth;
            HealthChanged?.Invoke(_health, _maxHealth);
            LevelUpped?.Invoke();
            TryLevelUp();
        }
    }

    public void SetMaxExperience(PlayerParameterInt experience)
    {
        _maxExperience = experience.CurrentValue;
    }

    public void AddHealth(IHealtable healtable)
    {
        _health += (int)healtable.Health;
        if (_health >= _maxHealth)
            _health = _maxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void AddMoney(IMoneySource money)
    {
        _money += (int)money.Number;
    }

    public void SetMaxHealth(PlayerParameterInt maxHealth)
    {
        _maxHealth = maxHealth.CurrentValue;
        _health = _maxHealth;
        MaxHealthChanged?.Invoke(_maxHealth);
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void SetDemage(PlayerParameterInt demage)
    {
        _demage = demage.CurrentValue;
        _swordHitter.SetDemage(this);
    }

    public ISaveableStruct GetSaveData()
    {
        PlayerDataSave playerDataSave = new PlayerDataSave(this);
        return playerDataSave;
    }

    public void SetSaveData(ISaveableStruct saveableStruct)
    {
        if (saveableStruct is PlayerDataSave playerDataSave)
        {
            _health = playerDataSave.CurrentHealth;
            _experience = playerDataSave.CurrentExperience;
            HealthChanged?.Invoke(_health, _maxHealth);
            ExperienceChanged?.Invoke(_experience, _maxExperience);
        }
    }
}

[System.Serializable]
public struct PlayerDataSave : ISaveableStruct
{
    public int CurrentHealth;
    public int CurrentExperience;

    public PlayerDataSave(Player player)
    {
        CurrentHealth = player.Health;
        CurrentExperience = player.Experience;
    }
}
