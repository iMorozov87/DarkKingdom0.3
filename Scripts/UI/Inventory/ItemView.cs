using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] Button _button;

    private Item _item;
    private string _name;
    private Sprite _sprite;
    private string _description;
    private uint _price;    

    public Item Item => _item;

    public event UnityAction<Item> ItemViewClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnViewClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnViewClick);
    }

    private void OnViewClick()
    {
        ItemViewClicked?.Invoke(_item);
    }

    public void Init(Item item)
    {
        _item = item;
        _name = item.Name;
        _icon.sprite= item.Sprite;
        _description = item.Description;
        _price = item.Price;
    }
}
