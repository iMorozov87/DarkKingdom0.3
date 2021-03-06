using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Transform _container;
    [SerializeField] private ItemView _itemViewTemplate;
    [SerializeField] private ItemProportiesView _itemProportiesView;

    private Inventory _inventory;
    private List<ItemView> _itemViews= new List<ItemView>();

    private void Awake()
    {
        Player player = _playerSpawner.GetPlayer();
        _inventory = player.GetComponent<Inventory>();  
    }

    private void OnEnable()
    {        
        _inventory.ItemsAdded += OnItemViewAdded;
        _inventory.ItemRemoved += OnItemViewRemoved;
        _itemProportiesView.ItemUsed += OnItemUsed;
    }

    private void OnDisable()
    {
        _inventory.ItemsAdded -= OnItemViewAdded;
        _inventory.ItemRemoved -= OnItemViewRemoved;
        _itemProportiesView.ItemUsed -= OnItemUsed;
    }

    private void OnItemUsed(Item item)
    {
        _inventory.RemoveItem(item);  
    }

    private void OnItemViewAdded(Item item)
    {
        ItemView itemView = Instantiate(_itemViewTemplate, _container);
        itemView.Init(item);
        itemView.ItemViewClicked += OnItemViewClick;
       _itemViews.Add(itemView);
    }

    private void OnItemViewClick(Item item)
    {
        _itemProportiesView.ShowItem(item);
    }

    private void OnItemViewRemoved(Item item)
    {
        foreach (var itemView in _itemViews)
        {
            if(itemView.Item == item)
            {
                _itemViews.Remove(itemView);
                itemView.ItemViewClicked -= OnItemViewClick;
                Destroy(itemView.gameObject);
                return;
            }
        }
        _itemProportiesView.Reset();
    }
}
