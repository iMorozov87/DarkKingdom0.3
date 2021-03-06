using System;
using System.Collections;
using UnityEngine;

public class ItemInstanse : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        if (_item.Sprite != null)
            _spriteRenderer.sprite = _item.Sprite;
    }

    public void SetItem(Item item)
    {
        _item = item;
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Chest>(out Chest chest)
            && chest.IsOpen == false)
        {
            if (_item is QuestItem questItem)
            {
                chest.AddQuestItem(questItem);
            }
            else
                chest.AddItem(_item);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent<Inventory>(out Inventory inventory))
        {
            if (_item is QuestItem questItem)
            {
                gameObject.TryGetComponent<QuestObject>(out QuestObject questObject);
                questObject.DoneCondition();
                inventory.AddQuestItem(questItem);
            }

            else
                inventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}
