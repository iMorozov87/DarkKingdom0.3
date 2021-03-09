using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenStarter : MonoBehaviour
{
    [SerializeField] private List<Button> _deactivationButtons;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Menu _menuDisplay;

    private Player _player;

    private void Awake()
    {
        _player = _playerSpawner.GetPlayer();
    }

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
        foreach (var button in _deactivationButtons)
        {
            button.interactable = false;
        } 
        _menuDisplay.gameObject.SetActive(true);
    }
}
