using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Messenger : MonoBehaviour
{
    public event UnityAction<string> MessengePrepared;

    protected void PrepareMessage(string message)
    {
        MessengePrepared?.Invoke(message);
    }
}
