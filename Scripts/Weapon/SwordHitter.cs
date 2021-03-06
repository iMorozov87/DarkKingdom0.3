using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class SwordHitter : MonoBehaviour
{
    [SerializeField] private float _hitForce = 10;

    private int _demage = 5;
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _attackIsActive = false;

    public bool AttackIsActive => _attackIsActive;

    public void SetDemage(Player player)
    {
        _demage = player.Demage;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _audioSource.Play();
    }

    private void LaunchAttack()
    {
        _attackIsActive = true;
    }

    private void EndAttack()
    {
        _attackIsActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_attackIsActive && collision)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.ApplyDemage(_demage, transform.position);
                FlyAwayFromHit(enemy);
                EndAttack();
            }
        }
    }

    private void FlyAwayFromHit(Enemy enemy)
    {
        Vector2 direction = (enemy.transform.position - transform.position).normalized;
        Rigidbody2D rigidbody2D = enemy.Rigidbody2D;
        rigidbody2D.AddForce(direction * _hitForce, ForceMode2D.Impulse);
    }
}
