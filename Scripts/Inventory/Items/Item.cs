using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item/Item"), System.Serializable]
public class Item : ScriptableObject
{
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    [SerializeField] public Sprite _sprite;
    [SerializeField] public uint _price;

    public string Name  => _name;
    public string Description => _description; 
    public Sprite Sprite => _sprite; 
    public uint Price =>_price;
}
