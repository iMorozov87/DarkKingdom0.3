using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/QuestItem"), System.Serializable]
public class QuestItem : Item
{
    public Quest Quest;
}
