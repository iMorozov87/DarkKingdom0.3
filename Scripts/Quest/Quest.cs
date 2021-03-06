using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Quest"), System.Serializable]
public class Quest : ScriptableObject
{
    [SerializeField] private string _nameTheQuest;
    [SerializeField, Multiline(5)] private string _description;
    [SerializeField] private int _numderCondition;
    [SerializeField] private QuestItem _item;
    [SerializeField] private int _experience;
    [SerializeField] private Item _itemReward;

    private int _numberTakenCondition = 0;
    private bool _isActive = false;
    private bool _isReadyDelivery = false;

    public string NameTheQuest => _nameTheQuest;
    public bool IsActive => _isActive;
    public bool IsReadyDelivery => _isReadyDelivery;
    public int NumberCondition => _numderCondition;
    public int NumberTakenCondition => _numberTakenCondition;
    public int Experienxe => _experience;
    public Item Item => _item;
    public Item ItemReward => _itemReward;

    public event UnityAction<Quest> ConditionsAreMet;
    public event UnityAction<Quest> QuestCompleted;
    public event UnityAction<Quest> DoneConditionAdded;
    public event UnityAction<QuestItem> ItemCollected;
    public event UnityAction<Quest> QuestActivated;
    public event UnityAction<Quest> SavedQuestActivated;
    public event UnityAction<Quest> SavedQuestCompleted;

    public string GetDescription()
    {
        return _description;
    }

    public void AddDoneCondition()
    {
        if (_isActive == false && _isReadyDelivery == false)
        {
            ActivateQuest();
        }

        if (_isActive == true && _isReadyDelivery == false)
        {
            _numberTakenCondition++;
            DoneConditionAdded?.Invoke(this);
            if (_numberTakenCondition >= _numderCondition)
            {
                _isReadyDelivery = true;
                ConditionsAreMet?.Invoke(this);
            }
        }
    }

    public void ActivateQuest()
    {
        if (_isActive == false && _isReadyDelivery == false)
        {
            _isActive = true;
            QuestActivated?.Invoke(this);
        }
    }

    public void DeactivateQuest()
    {
        if (_isActive && _isReadyDelivery)
        {
            QuestCompleted?.Invoke(this);
            _isActive = false;
            if (_item != null)
                ItemCollected?.Invoke(_item);
        }
    }

    public void SetSaveData(QuestData questData)
    {
        _nameTheQuest = questData.NameTheQuest;
        _numberTakenCondition = questData.NumberTakenCondition;
        _isActive = questData.IsActive;
        _isReadyDelivery = questData.IsReadyDelivery;

        if (_isActive == true)
        {
            QuestActivated?.Invoke(this);
            SavedQuestActivated?.Invoke(this);

            if (_isReadyDelivery == true)
            {
                ConditionsAreMet?.Invoke(this);
            }
        }
        if (_isActive == false && _isReadyDelivery == true)
            SavedQuestCompleted?.Invoke(this);
    }

    public void Reset()
    {
        _numberTakenCondition = 0;
        _isActive = false;
        _isReadyDelivery = false;
        ConditionsAreMet = null;
        QuestCompleted = null;
        ItemCollected = null;
        QuestActivated = null;
        SavedQuestActivated = null;
        SavedQuestCompleted = null;
    }

    public QuestData GetSaveData()
    {
        QuestData questData = new QuestData(this);
        Reset();
        return questData;
    }
}
