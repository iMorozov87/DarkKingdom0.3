using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestJournal : MonoBehaviour
{
    [SerializeField] private QuestNameButton _questNameButtonTemplate;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Transform _container;

    private List<QuestNameButton> _questButtons = new List<QuestNameButton>();
    private QuestNameButton _selectionButton;

    public event UnityAction<QuestNameButton> QuestButtonSetted;  
    public event UnityAction<QuestNameButton> QuestButtonDescriptionChanged;

    private void OnEnable()
    {
        if (_selectionButton != null)
            _selectionButton.SetSelection(true);
    }

    public void SetQuest(Quest newQuest)
    {              
        QuestNameButton newQuestButton = Instantiate(_questNameButtonTemplate, _container);
        newQuestButton.AddQuest(newQuest, _description);
        newQuestButton.DeletionPrepared += OnDeletionPrapered;
        newQuestButton.Selected += SetSelected;
        newQuestButton.QuestStatusChanged += OnQuestStatusChanged;   

        _questButtons.Add(newQuestButton);
        QuestButtonSetted(newQuestButton);
    }

    private void OnQuestStatusChanged(QuestNameButton questNameButton)
    {
        QuestButtonDescriptionChanged?.Invoke(questNameButton);
    }

    private void SetSelected(QuestNameButton questNameButton)
    {
        _selectionButton = questNameButton;
    }

    private void OnDeletionPrapered(QuestNameButton questNameButton)
    {
        questNameButton.Selected -= SetSelected;
        questNameButton.DeletionPrepared -= OnDeletionPrapered;
        questNameButton.QuestStatusChanged -= OnQuestStatusChanged;

        _questButtons.Remove(questNameButton);
        Destroy(questNameButton.gameObject);
    }
}