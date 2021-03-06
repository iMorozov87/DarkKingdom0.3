using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackStarter : MonoBehaviour
{
    [SerializeField] private float _timeReloadAttack = 1f;

    private bool _readyAttackEnemy = true;
    private Player _target;

    public Player Target => _target;

    public event UnityAction TargetReached;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_readyAttackEnemy)
        {
            if (collision.TryGetComponent<Player>(out Player target))
            {
                _target = target;
                TargetReached?.Invoke();
                StartCoroutine(ReloadAttack());
            }
        }
    }

    private IEnumerator ReloadAttack()
    {
        _readyAttackEnemy = false;
        yield return new WaitForSeconds(_timeReloadAttack);
        _readyAttackEnemy = true;
    }
}
