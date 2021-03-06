using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestSource : MonoBehaviour
{
    [SerializeField] private Quest[] _quests;

    private int _indexQuest = 0;
    private Quest _currentQuest;

    public event UnityAction<Quest> ChangedQuest;

    private void Awake()
    {
        if (_quests.Length > 0)
        {
            _currentQuest = _quests[_indexQuest];
            _currentQuest.QuestCompleted += ChangeCurrentQuest;
        }
    }

    private void Start()
    {
        ChangedQuest?.Invoke(_currentQuest);
    }

    private void OnEnable()
    {
        foreach (var quest in _quests)
        {
            quest.SavedQuestActivated += SetCurrentSavedQuest;
            quest.SavedQuestCompleted += CheckCopletedCurrentQuest;
        }
    }

    private void OnDisable()
    {
        foreach (var quest in _quests)
        {
            quest.SavedQuestActivated -= SetCurrentSavedQuest;
            quest.SavedQuestCompleted -= CheckCopletedCurrentQuest;
        }
    }
    private void CheckCopletedCurrentQuest(Quest completedQuest)
    {
        int lastIndex = _quests.Length - 1;

        if(completedQuest.NameTheQuest == _quests[lastIndex].NameTheQuest)
        {
            _currentQuest = null;
            _indexQuest = lastIndex;
            ChangedQuest?.Invoke(_currentQuest);
            return;
        }   
      
        for (int i = 0; i < _quests.Length; i++)
        {
            if (_quests[i].NameTheQuest == completedQuest.NameTheQuest)
            {
                if (_indexQuest < i)
                {
                    ChangeCurrentQuest(completedQuest);
                    return;                    
                }
            }
        }
    }

    private void ChangeCurrentQuest(Quest quest)
    {
        _indexQuest++;

        _currentQuest.QuestCompleted -= ChangeCurrentQuest;

        if (_indexQuest < _quests.Length)
        {
            _currentQuest = _quests[_indexQuest];
            _currentQuest.QuestCompleted += ChangeCurrentQuest;
        }

        if (_indexQuest >= _quests.Length)
        {
            _currentQuest = null;
        }

        ChangedQuest?.Invoke(_currentQuest);
    }

    private void SetCurrentSavedQuest(Quest newCurrentQuest)
    {
        if (_currentQuest != null)
            _currentQuest.QuestCompleted -= ChangeCurrentQuest;

        for (int i = 0; i < _quests.Length; i++)
        {
            if (newCurrentQuest.NameTheQuest == _quests[i].NameTheQuest)
            {
                _currentQuest = _quests[i];
                _currentQuest.QuestCompleted += ChangeCurrentQuest;
                _indexQuest = i;
                i = _quests.Length;
            }
        }

        ChangedQuest?.Invoke(_currentQuest);
    }
}
