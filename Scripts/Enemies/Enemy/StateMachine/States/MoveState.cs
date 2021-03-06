using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public abstract class MoveState : State
{    
    [SerializeField] protected float Speed;

    protected Vector3 TargetPoint;
    protected Enemy Enemy;
    protected Rigidbody2D Rigidbody2D;
    protected Animator EnemyAnimator;
    protected bool IsPlayingAnimation = false;
    protected bool DiretionRight = true;

    public event UnityAction<Vector2> Flipped;

    protected void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Enemy = GetComponent<Enemy>();
        Initialize();
    }

    protected abstract void Initialize();

    protected void Update()
    {
        CheckTarget();
        Rigidbody2D.velocity = Vector2.zero;
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Speed * Time.deltaTime);
        TryPlayAnimation();
    }
    protected abstract void CheckTarget();

    protected void TryPlayAnimation()
    {
        if (IsPlayingAnimation == false)
        {
            EnemyAnimator.SetBool("Run", true);
            IsPlayingAnimation = true;
        }
    }

    protected void SetDirection()
    {
        if (transform.localScale.x < 0)
            DiretionRight = false;
        else
            DiretionRight = true;
    }

    protected void TryFlip(Vector3 targetPoint)
    {
        if (transform.position.x < targetPoint.x && DiretionRight == false)
            Flip();
        else if (transform.position.x > targetPoint.x && DiretionRight == true)
            Flip();
    }

    protected  void Flip()
    {
        DiretionRight = !DiretionRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        Flipped?.Invoke(transform.localScale);
    }
}
