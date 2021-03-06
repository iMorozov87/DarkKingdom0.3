using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour
{
    [SerializeField] private AnswerButton _answerButtonTemplate;
    [SerializeField] private TMP_Text _nameNPC;
    [SerializeField] private TMP_Text _speechNPC;
    [SerializeField] private Transform _contaiterButtons;

    private Dialog _dialog;
    private List<AnswerButton> _answerButtons;
    private NPC _npc;
    private Quest _currentQuest;

    public void SetNPC(NPC npc)
    {
        _npc = npc;
        Init();
    }

    public void Init()
    {
        _dialog = _npc.GetDialog();
        _nameNPC.text = _npc.Name;
        _speechNPC.text = _dialog.CurrentSpeeckNPC.Text;
        _answerButtons = CreateListAnswerButtons(_dialog);
    }

    public void SetCurrentQuest(Quest quest)
    {
        _currentQuest = quest;
    }

    private List<AnswerButton> CreateListAnswerButtons(Dialog dialog)
    {
        List<AnswerButton> answerButtons = new List<AnswerButton>();
        Answer[] answers = dialog.CurrentSpeeckNPC.Answers;

        if (_answerButtons != null)
        {
            DestroyButtons();
        }

        for (int i = 0; i < answers.Length; i++)
        {
            AnswerButton newAnswerButton = CreateAnswerButton(answers[i]);
            newAnswerButton.AnswerButtonClicked += OnAnswerButtonClicked;
            answerButtons.Add(newAnswerButton);
        }
        return answerButtons;
    }

    private void OnAnswerButtonClicked(AnswerButton answerButton)
    {
        Answer answer = answerButton.CurrentAnswer;
        switch (answer.QuestState)
        {
            case QuestState.Begin:
                _dialog.OnBeginNewQuest();
                break;
            case QuestState.End:
                _dialog.OnEndQuest();
                break;
            case QuestState.AddCondition:
                _dialog.OnAddQuestCondition();
                break;
        }

        _dialog.SetCurrentSpeeck(answer.NextSpeecskNPC);
        answerButton.AnswerButtonClicked -= OnAnswerButtonClicked;
    }

    private AnswerButton CreateAnswerButton(Answer answer)
    {
        AnswerButton answerButton = Instantiate(_answerButtonTemplate, _contaiterButtons);
        answerButton.SetAnswer(answer);
        return answerButton;
    }

    private void DestroyButtons()
    {
        int numberButtons = _answerButtons.Count;
        for (int i = 0; i < numberButtons; i++)
        {
            Destroy(_answerButtons[i].gameObject);
        }
        _answerButtons.Clear();
    }
}
