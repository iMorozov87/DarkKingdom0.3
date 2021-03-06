using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Door))]
public class DoorOpener : MonoBehaviour
{
    private Door _door;

    private void Awake()
    {
        _door = GetComponent<Door>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_door.LockOpen)
            {
                _door.Open();
                return;
            }
            else
            {
                Inventory inventory = player.GetComponent<Inventory>();
                if (inventory.TryGetKey(_door.Key))
                {
                    inventory.RemoveItem(_door.Key);
                    _door.SetLockState(true);
                    _door.Open();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_door.LockOpen == true)
                _door.Close();
        }
    }
}
