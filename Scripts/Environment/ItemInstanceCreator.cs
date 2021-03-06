using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstanceCreator : MonoBehaviour
{
    [SerializeField] private ItemInstanse _itemInstanse;

    private void CreateQuestItemInstanse(ItemInstanse itemInstanse, QuestItem questItem)
    {       
        QuestObject questObject = itemInstanse.gameObject.AddComponent<QuestObject>();
        questObject.SetQuest(questItem.Quest);
    }

    public void CreateItemInstanse(Item item)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        var newItemInstance = Instantiate(_itemInstanse, transform.position +
            new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)), Quaternion.identity);
        newItemInstance.SetItem(item);
        if (item is QuestItem questItem)
            CreateQuestItemInstanse(newItemInstance, questItem);
    }
}
