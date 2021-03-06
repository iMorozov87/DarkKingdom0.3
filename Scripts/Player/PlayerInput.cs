using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private Joystick _joystick;
    private PlayerMover _playerMover;
    private SwordHitter _swordHitter;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _playerMover = GetComponent<PlayerMover>();
        _swordHitter = GetComponentInChildren<SwordHitter>();
    }

    private void Update()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        float moveHorizontal = _joystick.Horizontal;
        float moveVertical = _joystick.Vertical;
#else
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
#endif
        _playerMover.TryMove(moveHorizontal, moveVertical);
    }

    public void ToAttack()
    {
        _swordHitter.Attack();
    }
}
