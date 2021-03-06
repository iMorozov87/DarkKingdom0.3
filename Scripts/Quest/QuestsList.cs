using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsList : MonoBehaviour, ISavable, ILoadable
{
    [SerializeField] private Quest[] _quests;
    [SerializeField] private QuestJournal _questJournal;

    private void OnEnable()
    {
        foreach (var quest in _quests)
        {
            quest.QuestActivated += OnQuestActivated;
        }
    }

    private void OnDisable()
    {
        foreach (var quest in _quests)
        {
            quest.QuestActivated -= OnQuestActivated;
            quest.Reset();
        }
    }

    private void OnDestroy()
    {
        foreach (var quest in _quests)
        {
            quest.Reset();
        }
    }

    private void OnQuestActivated(Quest quest)
    {
        _questJournal.SetQuest(quest);
    }

    public void SetSaveData(ISaveableStruct saveableStruct)
    {
        if (saveableStruct is QuestsListData questsListData)
        {
            foreach (var questData in questsListData.Quests)
            {
                foreach (var quest in _quests)
                {
                    if (questData.NameTheQuest == quest.NameTheQuest)
                        quest.SetSaveData(questData);
                }
            }
        }
    }

    public ISaveableStruct GetSaveData()
    {
        QuestsListData questsListData = new QuestsListData(_quests);
        return questsListData;
    }
}

[System.Serializable]
public struct QuestsListData : ISaveableStruct
{
    public List<QuestData> Quests;
    public QuestsListData(Quest[] quests)
    {
        Quests = new List<QuestData>();
        foreach (var quest in quests)
        {
            QuestData questData = new QuestData(quest);
            Quests.Add(questData);
        }
    }
}

[System.Serializable]
public struct QuestData
{
    public string NameTheQuest;
    public int NumberTakenCondition;
    public bool IsActive;
    public bool IsReadyDelivery;

    public QuestData(Quest quest)
    {
        NameTheQuest = quest.NameTheQuest;
        NumberTakenCondition = quest.NumberTakenCondition;
        IsActive = quest.IsActive;
        IsReadyDelivery = quest.IsReadyDelivery;
    }
}


