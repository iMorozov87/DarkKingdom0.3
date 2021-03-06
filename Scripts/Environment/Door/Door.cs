using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private Key _key;
    [SerializeField] private BoxCollider2D _collider2D;
    [SerializeField] private bool _lockOpen = false;

    public Key Key => _key;
    public bool LockOpen => _lockOpen;

    public event UnityAction Oppened;
    public event UnityAction Closed;

    public void Open()
    {
        Oppened?.Invoke();
        _collider2D.enabled = false;      
    }

    public void Close()
    {
        Closed?.Invoke();
        _collider2D.enabled = true;
    }

    public void SetLockState(bool lockOpen)
    {
        _lockOpen = lockOpen;
    }
}
