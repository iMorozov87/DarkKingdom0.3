using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieder : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private SwordHitter _swordHitter;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _animator.SetTrigger("Died");
        _playerInput.enabled = false;
        _swordHitter.gameObject.SetActive(false);
    }
}
