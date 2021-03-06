using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestMessenger : Messenger
{
    [SerializeField] private QuestJournal _questJournal;
    [SerializeField] private string _messageQuestActivated;
    [SerializeField] private string _messageQuestCompleted;
    [SerializeField] private string _messageDoneConditionAdded;
    [SerializeField] private string _messageConditionsAreMet;

    private void OnEnable()
    {
        _questJournal.QuestButtonSetted += OnQuestButtonSetted;
    }

    private void OnDisable()
    {
        _questJournal.QuestButtonSetted -= OnQuestButtonSetted;
    }

    private void OnQuestButtonSetted(QuestNameButton questNameButton)
    {
        Quest newQuest = questNameButton.Quest;
        OnQuestActivated(newQuest);
        MonitorStatusQuest(newQuest);
    }

    private void MonitorStatusQuest(Quest newQuest)
    {
        newQuest.ConditionsAreMet += OnConditionsAreMet;
        newQuest.QuestCompleted += OnQuestCompleted;
        newQuest.DoneConditionAdded += OnDoneConditionAdded;
    }

    private void OnQuestActivated(Quest quest)
    {
        string newMessege = _messageQuestActivated + " " + "\"" + quest.NameTheQuest + "\"";
        PrepareMessage(newMessege);
    }

    private void OnConditionsAreMet(Quest quest)
    {
        string newMessege = _messageConditionsAreMet + " " + "\"" + quest.NameTheQuest + "\"";
        PrepareMessage(newMessege);
    }

    private void OnQuestCompleted(Quest quest)
    {
        string newMessage = _messageQuestCompleted + " " + "\"" + quest.NameTheQuest + "\"";
        PrepareMessage(newMessage);
        quest.ConditionsAreMet -= OnConditionsAreMet;
        quest.QuestCompleted -= OnQuestCompleted;
        quest.DoneConditionAdded -= OnDoneConditionAdded;
    }

    private void OnDoneConditionAdded(Quest quest)
    {
        string newMessage ="\"" +quest.NameTheQuest + "\"" + " " + _messageDoneConditionAdded + " " + quest.NumberTakenCondition
            + "/" + quest.NumberCondition;
        PrepareMessage(newMessage);
    }
}

