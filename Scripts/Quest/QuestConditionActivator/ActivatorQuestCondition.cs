using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatorQuestCondition : MonoBehaviour
{
    [SerializeField] protected Quest Quest;

    protected void OnEnable()
    {
        Quest.QuestActivated += OnQuestActivated;
    }

    protected void OnDisable()
    {
        Quest.QuestActivated -= OnQuestActivated;
    }

    protected abstract void OnQuestActivated(Quest quest);
}
