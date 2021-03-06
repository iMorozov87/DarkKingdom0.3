using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] public string Text;
    [SerializeField] public SpeeckNPC NextSpeecskNPC;
    [SerializeField] public QuestState QuestState = QuestState.None;
}

public enum QuestState
{
    None,
    Begin,
    End,
    AddCondition
}
