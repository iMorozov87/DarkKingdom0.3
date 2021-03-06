using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeeckNPC : MonoBehaviour
{
   [SerializeField] public string Text;
   [SerializeField] public Answer[] Answers;
   [SerializeField] public bool IsBeginQuest = false;
}
