using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory : MonoBehaviour, ISavable, ILoadable
{
    [SerializeField] private int _money = 0;
    [SerializeField] private List<Item> _allVariantsItems;

    private List<Item> _currentItems = new List<Item>();
    private Dictionary<string, Item> _itemsDictionary = new Dictionary<string, Item>();

    public event UnityAction<Item> ItemsAdded;
    public event UnityAction<Item> ItemRemoved;

    public int Money => _money;

    private void Awake()
    {
        _itemsDictionary = CreateItemsDictionary(_allVariantsItems);
    }

    private Dictionary<string, Item> CreateItemsDictionary(List<Item> allVariantsItems)
    {
        Dictionary<string, Item> itemsDictionary = new Dictionary<string, Item>();

        foreach (var variantItem in allVariantsItems)
        {
            itemsDictionary.Add(variantItem.Name, variantItem);
        }
        return itemsDictionary;
    }

    public void AddItem(Item item)
    {
        _currentItems.Add(item);
        ItemsAdded?.Invoke(item);
    }

    public void AddQuestItem(QuestItem questItem)
    {
        AddItem(questItem);
        questItem.Quest.ItemCollected += RemoveItem;
    }

    public void AddSaveQuestItem(Quest quest)
    {
        quest.ItemCollected += RemoveItem;
    }

    public void RemoveItem(Item item)
    {
        ItemRemoved?.Invoke(item);
        _currentItems.Remove(item);
    }

    public bool TryGetKey(Key key)
    {
        return _currentItems.Contains(key);
    }

    private void AddAllItems(ListItemsData listItemsData)
    {
        foreach (var itemsData in listItemsData.ItemDatas)
        {
            if (_itemsDictionary.ContainsKey(itemsData.Name))
            {
                Item newItem = _itemsDictionary[itemsData.Name];
                if (newItem is QuestItem questItem)
                    AddQuestItem(questItem);
                else
                    AddItem(newItem);
            }
        }
    }

    private void RemoveAllItems()
    {
        for (int i = _currentItems.Count - 1; i >= 0; i--)
        {
            RemoveItem(_currentItems[i]);
        }
    }
    public ISaveableStruct GetSaveData()
    {
        ListItemsData listItemsData = new ListItemsData(_currentItems);
        return listItemsData;
    }
   
    public void SetSaveData(ISaveableStruct saveableStruct)
    {
        if (saveableStruct is ListItemsData listItemsData)
        {
            RemoveAllItems();
            AddAllItems(listItemsData);
        }
    }
}

[System.Serializable]
public struct ListItemsData : ISaveableStruct
{
    public List<ItemData> ItemDatas;

    public ListItemsData(List<Item> items)
    {
        ItemDatas = new List<ItemData>();
        foreach (var item in items)
        {
            ItemData itemData = new ItemData(item);
            ItemDatas.Add(itemData);
        }
    }
}

[System.Serializable]
public struct ItemData
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public uint Price;

    public ItemData(Item item)
    {
        Name = item.Name;
        Description = item.Description;
        Sprite = item.Sprite;
        Price = item.Price;
    }
}

