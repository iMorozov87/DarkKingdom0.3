using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestObject : MonoBehaviour
{
    [SerializeField] private Quest _quest;

    public Quest Quest => _quest;

    public void SetQuest(Quest quest)
    {
        _quest = quest;
    }
    public void DoneCondition()
    {
        _quest.AddDoneCondition();
    }
}
