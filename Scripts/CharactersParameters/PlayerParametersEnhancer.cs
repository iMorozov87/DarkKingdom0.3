using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerParametersEnhancer : MonoBehaviour, ISavable, ILoadable
{
    [SerializeField]private PlayerParameterInt _maxHealth;
    [SerializeField ]private PlayerParameterInt _demage;
    [SerializeField] private PlayerExperienceParameterInt _maxExperience;

    private int _pointsImprovement = 0;
    private Player _player;

    public PlayerParameterInt MaxHealth => _maxHealth;
    public PlayerParameterInt Demage => _demage;
    public PlayerExperienceParameterInt MaxExperience => _maxExperience;
    public int PointsImprovement => _pointsImprovement;

    public event UnityAction PlayerEnchanced;
    public event UnityAction PointsChanged;

    private void Awake()
    {            
        _player = GetComponent<Player>();
        SetPlayer();
    }

    private void Start()
    {
        PointsChanged?.Invoke();
    }

    private void OnEnable()
    {
        _player.LevelUpped += OnLevelUpped;
    }

    private void OnDisable()
    {
        _player.LevelUpped -= OnLevelUpped;
    }

    private void OnLevelUpped()
    {
        _pointsImprovement++;
        PointsChanged?.Invoke();
        PlayerEnchance(_maxExperience);
    }

    public void PlayerEnchance(PlayerParameterInt characterParameter)
    {
        characterParameter.IncreaseLevel();
        if (characterParameter == _maxHealth)
            _player.SetMaxHealth(_maxHealth);
        if (characterParameter == _demage)
            _player.SetDemage(_demage);
        if (characterParameter == _maxExperience)
            _player.SetMaxExperience(_maxExperience);  
        PlayerEnchanced?.Invoke();        
    }


    private void SetPlayer()
    {
        _player.SetMaxHealth(_maxHealth);
        _player.SetDemage(_demage);
        _player.SetMaxExperience(_maxExperience);
    }

    public ISaveableStruct GetSaveData()
    {
        CharacterParametersData parametersData = new CharacterParametersData(_maxHealth, _demage, _maxExperience, _pointsImprovement);        
        return parametersData;
    }
    
    public void SetSaveData(ISaveableStruct savebleStruct)
    {
       if(savebleStruct is CharacterParametersData characterParameters)
        {
            _maxHealth.SetSaveData(characterParameters.Health);
            _demage.SetSaveData(characterParameters.Demage);
            _maxExperience.SetSaveData(characterParameters.Experience);
            _pointsImprovement = characterParameters.PointsImprovement;
            SetPlayer();
            PlayerEnchanced?.Invoke();
            PointsChanged?.Invoke();
        }
    }

    public void RemovePoints()
    {
        _pointsImprovement--;
        PointsChanged?.Invoke();
    }
}

[System.Serializable] 
public struct CharacterParametersData:ISaveableStruct
{
    public CharacterParameterData Health;
    public CharacterParameterData Demage;
    public CharacterParameterData Experience;
    public int PointsImprovement;
    public CharacterParametersData(PlayerParameterInt health, PlayerParameterInt demage, PlayerParameterInt experience, int pointsImprovement)
    {
        Health = new CharacterParameterData(health);
        Demage = new CharacterParameterData(demage);
        Experience = new CharacterParameterData(experience);
        PointsImprovement = pointsImprovement;
    }
}

[System.Serializable]
public struct CharacterParameterData
{
    public string Name;
    public int StartValue;
    public int CurrentValue;
    public int DeltaValue;
    public int Level;

    public CharacterParameterData(PlayerParameterInt characterParameter)
    {
        Name = characterParameter.Name;
        StartValue = characterParameter.StartValue;
        CurrentValue = characterParameter.CurrentValue;
        DeltaValue = characterParameter.DeltaValue;
        Level = characterParameter.Level;
    }
}