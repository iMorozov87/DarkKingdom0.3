using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/UsedItem/Potion"), System.Serializable]
public class Potion : UsedItem, IHealtable
{
    [SerializeField] private uint _health;

    public uint Health => _health;

    public override void Use(Player player)
    {
        player.AddHealth(this);
    }
}
