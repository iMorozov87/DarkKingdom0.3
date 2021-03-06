using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [Range(1, 10), SerializeField] private float _speed;

    private Vector3 _movement;
    private Animator _animator;
    private bool _direcrionRigth = true;

    public Vector3 DirectionMovement => _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 localScale)
    {
        transform.localScale = localScale;
        if (transform.localScale.x == -1)
            _direcrionRigth = false;
    }

    public void TryMove(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            int maxMovement = 1;
            _movement = Vector2.ClampMagnitude(new Vector2(moveHorizontal, moveVertical), maxMovement);
            TryFlip(moveHorizontal);
            transform.Translate(_movement * Time.deltaTime * _speed);
            _animator.SetBool("Run", true);
        }
        else
        {
            _movement = Vector3.zero;
            _animator.SetBool("Run", false);
        }
    }

    private void TryFlip(float moveHorizontal)
    {
        if (moveHorizontal < 0 && _direcrionRigth == true)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && _direcrionRigth == false)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _direcrionRigth = !_direcrionRigth;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
