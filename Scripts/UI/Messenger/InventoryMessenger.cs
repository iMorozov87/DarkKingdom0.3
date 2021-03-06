using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMessenger : Messenger
{
    [SerializeField] private PlayerSpawner _playerSpawner;   
    [SerializeField] private ItemProportiesView _itemProportiesView;
    [SerializeField] private string _messageItemAdded;
    [SerializeField] private string _messageItemRemoved;
    [SerializeField] private string _messageItemUsed;

    private Inventory _inventory;  

    private void Awake()
    {
        Player player = _playerSpawner.GetPlayer();
        _inventory = player.GetComponent<Inventory>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        _inventory.ItemsAdded += OnItemAdded;
        _inventory.ItemRemoved += OnItemRemoved;
        _itemProportiesView.ItemUsed += OnItemUsed;
    }

    private void OnDisable()
    {
        _inventory.ItemsAdded -= OnItemAdded;
        _inventory.ItemRemoved -= OnItemRemoved;
        _itemProportiesView.ItemUsed -= OnItemUsed;
    }

    private void OnItemUsed(Item item)
    {
        string newMessage =$"{_messageItemUsed} \"{item.Name}\" ";
        PrepareMessage(newMessage);
    }

    private void OnItemRemoved(Item item)
    {
        if (item is UsedItem)
            return;
        string newMessage = $"{_messageItemRemoved} \"{item.Name}\" ";
        PrepareMessage(newMessage);
    }

    private void OnItemAdded(Item item)
    {
        string newMessage = $"{_messageItemAdded} \"{item.Name}\" ";
        PrepareMessage(newMessage);
    }
}
