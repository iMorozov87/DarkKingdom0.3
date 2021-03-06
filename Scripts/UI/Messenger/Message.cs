using System;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text _message;    

    public void SetText(string text)
    {
        _message.text = text;
    }

    public void SetTextSize(float size)
    {
        _message.fontSize = size;
    }
}
