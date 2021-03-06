using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestNameButton : MonoBehaviour
{
    [SerializeField] TMP_Text _nameQuest;
    [SerializeField] private Button _questButton;

    private Quest _quest;
    private TMP_Text _descriptionDisplay;
    private string _description;
    private bool _isSelected = false;

    public string Name => _nameQuest.text;
    public Quest Quest => _quest;

    public event UnityAction<QuestNameButton> Selected;
    public event UnityAction<QuestNameButton> DeletionPrepared;
    public event UnityAction<QuestNameButton> QuestStatusChanged;

    private void OnEnable()
    {
        _questButton.onClick.AddListener(OnClickQuestButton);
        TryOnSelect();
    }

    private void OnDisable()
    {
        _isSelected = false;
        _questButton.onClick.RemoveListener(OnClickQuestButton);
    }

    private void TryOnSelect()
    {
        if (_isSelected)
        {
            _questButton.Select();
            SetDescriptionDisplay();
        }
    }

    public void SetSelection(bool isSelected)
    {
        _isSelected = isSelected;
    }

    public void AddQuest(Quest quest, TMP_Text descriptionDisplay)
    {
        _quest = quest;
        _quest.QuestCompleted += OnQuestComleted;
        _quest.DoneConditionAdded += OnDoneConditionAdded;
        _descriptionDisplay = descriptionDisplay;

        _nameQuest.text = _quest.NameTheQuest;
        _description = _quest.GetDescription();
        _isSelected = true;
        TrySetDescriptionDisplay();
    }

    private void OnDoneConditionAdded(Quest quest)
    {
        QuestStatusChanged?.Invoke(this);
        SetDescriptionDisplay();
    }

    private void OnQuestComleted(Quest quest)
    {
        _quest.QuestCompleted -= OnQuestComleted;
        _quest.DoneConditionAdded -= OnDoneConditionAdded;
        _descriptionDisplay.text = String.Empty;
        DeletionPrepared?.Invoke(this);
    }

    public void OnClickQuestButton()
    {
        Selected?.Invoke(this);
        _isSelected = true;
        TrySetDescriptionDisplay();
    }

    private void TrySetDescriptionDisplay()
    {
        if (_quest != null && _isSelected == true)
            SetDescriptionDisplay();
    }

    private void SetDescriptionDisplay()
    {
        _descriptionDisplay.text = ($"{_description}" +
     $"\nВыполнено условий: {_quest.NumberTakenCondition}/{_quest.NumberCondition}");
    }
}
