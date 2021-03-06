using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private NPC _npc;
    [SerializeField] private DialogDisplay _dialogDisplay;
    [SerializeField] private SpeeckNPC _currentSpeeckNPC;
    [SerializeField] private SpeeckNPC _speeckIfQuestIsActive;
    [SerializeField] private SpeeckNPC _speeckIfQuestIsCompleted;
    [SerializeField] private SpeeckNPC _speeckIfAllQuestIsEnd;

    private Quest _currentQuest;
    private string _beginSpeeck;

    public Quest CurrentQuest => _currentQuest;
    public SpeeckNPC CurrentSpeeckNPC => _currentSpeeckNPC;

    public void SetCurrentSpeeck(SpeeckNPC speeckNPC)
    {
        _currentSpeeckNPC = speeckNPC;
        TryChangeCurrentSpeeck(_currentQuest);
        _dialogDisplay.Init();
    }

    public void TryChangeCurrentSpeeck(Quest quest)
    {
        _currentQuest = TryGetCurrentQuest();

        if (_currentSpeeckNPC.IsBeginQuest)
        {
            if (_currentQuest == null)
            {
                _currentSpeeckNPC = _speeckIfAllQuestIsEnd;
                return;
            }

            if (_npc.GetCurrentQuest().IsActive)
            {
                _currentSpeeckNPC = _speeckIfQuestIsActive;
            }
            else
            {
                if (_beginSpeeck == null)
                {
                    _beginSpeeck = _currentSpeeckNPC.Text;
                }

                _currentSpeeckNPC.Text = _beginSpeeck + " " + _currentQuest.GetDescription();
            }
        }
        CheckCompletionQuest();
    }

    public void OnAddQuestCondition()
    {
        _npc.AddQuestCondition();
    }

    private void CheckCompletionQuest()
    {
        if (_currentQuest != null)
        {
            if (_currentQuest.IsActive && _currentQuest.IsReadyDelivery)
            {
                _currentSpeeckNPC = _speeckIfQuestIsCompleted;
                _currentQuest.ConditionsAreMet -= TryChangeCurrentSpeeck;
                _currentQuest = null;
            }
        }
    }

    private Quest TryGetCurrentQuest()
    {
        if (_currentSpeeckNPC.IsBeginQuest)
        {
            _currentQuest = _npc.GetCurrentQuest();
        }
        return _currentQuest;
    }

    public void OnBeginNewQuest()
    {
        _npc.GetCurrentQuest().ActivateQuest();
        _npc.GetCurrentQuest().ConditionsAreMet += TryChangeCurrentSpeeck;
    }

    public void OnBeginSaveQuest()
    {
        _currentQuest = _npc.GetCurrentQuest();
        _npc.GetCurrentQuest().ConditionsAreMet += TryChangeCurrentSpeeck;        
    }

    public void OnEndQuest()
    {
        _npc.GetCurrentQuest().ConditionsAreMet -= TryChangeCurrentSpeeck;
        _npc.GetCurrentQuest().DeactivateQuest();
    }
}



