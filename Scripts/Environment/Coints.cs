using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coints : MonoBehaviour, IMoneySource
{
    [SerializeField] private uint _number;

    private AudioSource _audioSource;

    public uint Number => _number;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetNumber(uint number)
    {
        _number = number;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player> (out Player player))
        {
            player.AddMoney(this);
            _audioSource.Play();
            Destroy(gameObject,0.2f);
        }
    }
}



