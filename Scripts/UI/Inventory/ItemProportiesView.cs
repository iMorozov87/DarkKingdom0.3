using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemProportiesView : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Button _buttonUseItem;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _name;

    private Item _item;
    private Player _player;

    public event UnityAction<Item> ItemUsed;

    private void Awake()
    {
        _buttonUseItem.gameObject.SetActive(false);
        _player = _playerSpawner.GetPlayer();
    }

    private void OnEnable()
    {
        _buttonUseItem.onClick.AddListener(UseItem);
    }

    private void OnDisable()
    {
        _buttonUseItem.onClick.RemoveListener(UseItem);
    }

    private void UseItem()
    {
        if (_item is UsedItem usedItem)
        {
            usedItem.Use(_player);
            ItemUsed?.Invoke(_item);
            Reset();
        }
    }

    public void Reset()
    {
        _name.text = string.Empty;
        _description.text = string.Empty;
        _buttonUseItem.gameObject.SetActive(false);
    }

    public void ShowItem(Item item)
    {
        _item = item;
        _name.text = item.Name;
        _description.text = item.Description;
        if (item is UsedItem)
            _buttonUseItem.gameObject.SetActive(true);
        else
            _buttonUseItem.gameObject.SetActive(false);
    }
}
