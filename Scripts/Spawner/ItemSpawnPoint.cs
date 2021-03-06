using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPoint : SpawnPoint
{
    [SerializeField] private Item _item;
    [SerializeField] private ItemInstanse _itemInstanseTemplate;

    private ItemInstanse _itemInstanse;

    public override void Init(Quest quest)
    {
        _item = quest.Item;
        Init();
        QuestObject questObject = _itemInstanse.gameObject.AddComponent<QuestObject>();
        questObject.SetQuest(quest);
    }

    public override void Init()
    {
        _itemInstanse = Instantiate(_itemInstanseTemplate, transform.localPosition, Quaternion.identity);
        _itemInstanse.SetItem(_item);
    }
}
