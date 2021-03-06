using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    private PlayerInput _playerInput;
    private Button _attackButton;

    private void Awake()
    {
        _attackButton = GetComponent<Button>();
        _playerInput = _playerSpawner.GetPlayer().GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _attackButton.onClick.AddListener(OnAttackButtonClick);
    }

    private void OnDisable()
    {
        _attackButton.onClick.RemoveListener(OnAttackButtonClick);
    }

    private void OnAttackButtonClick()
    {
        _playerInput.ToAttack();
    }
}
