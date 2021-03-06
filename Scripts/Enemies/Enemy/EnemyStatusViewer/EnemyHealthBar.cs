using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private Enemy _enemy;
    private int _startHealth;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();        
    }

    private void Start()
    {
        _startHealth = _enemy.Health;
    }

    private void OnEnable()
    {
        _enemy.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        float minSize = 0;
        float maxSize = 1;      
        float newScaleHorizontal = Mathf.Clamp(((float)health / _startHealth), minSize, maxSize);
        transform.localScale = new Vector3(newScaleHorizontal * Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
