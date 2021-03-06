using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorQuestNPC : ActivatorQuestCondition
{
    [SerializeField] private NPC _npc;

    protected override void OnQuestActivated(Quest quest)
    {
        if (quest.IsReadyDelivery == false)
            _npc.gameObject.SetActive(true);
    }
}
