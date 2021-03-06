using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegerDisplay : MonoBehaviour
{
    [SerializeField] private Messenger _messenger;
    [SerializeField] private float _durationMessage = 3.0F;
    [SerializeField] private Message _messageTemplate;
    [SerializeField] private float _fontSize = 50.0F;

    private void OnEnable()
    {
        _messenger.MessengePrepared += OnMessengePrepared;
    }

    private void OnDisable()
    {
        _messenger.MessengePrepared -= OnMessengePrepared;
    }

    private void OnMessengePrepared(string message)
    {
        Message newMessage = CreateMessage(message);
        Destroy(newMessage.gameObject, _durationMessage);
    }

    private Message CreateMessage(string message)
    {     
        Message newMessage = Instantiate(_messageTemplate, transform);
        newMessage.SetText(message);
        newMessage.SetTextSize(_fontSize);
        return newMessage;
    }
}
