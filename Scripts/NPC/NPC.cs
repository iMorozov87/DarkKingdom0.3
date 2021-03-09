using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ItemInstanceCreator))]
public class NPC : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Dialog _dialog;
    [SerializeField] private PanelDoorman _menu;

    private ItemInstanceCreator _instanceCreator;
    private QuestSource _questSource;
    private Quest _currentQuest;
    private Player _player;

    public Dialog Dialog => _dialog;
    public Quest CurrentQuest => _currentQuest;
    public string Name => _name;

    public event UnityAction<NPC> OpenStartDialogButton;
    public event UnityAction CloseStartDialogButton;

    private void Awake()
    {
        _instanceCreator = GetComponent<ItemInstanceCreator>();
    }

    private void OnEnable()
    {
        CloseStartDialogButton += _menu.OnCloseStartDialogButton;
        OpenStartDialogButton += _menu.OnOpenStartDialogButton;

        if (TryGetComponent<QuestSource>(out QuestSource questSource))
        {
            _questSource = questSource;
            _questSource.ChangedQuest += OnChangedQuest;
        }
    }

    private void OnDisable()
    {
        CloseStartDialogButton -= _menu.OnCloseStartDialogButton;
        OpenStartDialogButton -= _menu.OnOpenStartDialogButton;

        if (TryGetComponent<QuestSource>(out QuestSource questSource))
        {
            _questSource.ChangedQuest -= OnChangedQuest;
        }
    }


    private void OnChangedQuest(Quest quest)
    {
        TryRewardPlayer();
        SetCurrentQuest(quest);
    }

    private void TryRewardPlayer()
    {
        if (_currentQuest != null && _player != null)
        {
            _player.AddExperience(_currentQuest.Experienxe);
            if (_currentQuest.ItemReward != null)
                _instanceCreator.CreateItemInstanse(_currentQuest.ItemReward);
        }
    }

    private void SetCurrentQuest(Quest quest)
    {
        _currentQuest = quest;

        if (_currentQuest != null && _currentQuest.IsReadyDelivery)
        {
            _dialog.OnBeginSaveQuest();
        }
    }

    public void AddQuestCondition()
    {
        GetComponent<QuestObject>().DoneCondition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            OpenStartDialogButton?.Invoke(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            CloseStartDialogButton?.Invoke();
    }
}
