using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyVisibilityRange : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    private Player _player;
    private bool _isTargetDetected = false;

    public Player Target => _player;

    public bool IsTargetDetected => _isTargetDetected;

    public event UnityAction PlayerDetected;
    public event UnityAction PlayerLosted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _isTargetDetected = true;
            PlayerDetected?.Invoke();            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerLosted?.Invoke();
            _isTargetDetected = false;            
            _player = player;
        }
    }
}
