using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorQuestSpawnPoint : ActivatorQuestCondition
{
    [SerializeField] private SpawnPoint _spawnerQuestCondition;

    protected override void OnQuestActivated(Quest quest)
    {
        if (quest.IsReadyDelivery == false)
            _spawnerQuestCondition.Init(quest);
    }
}
