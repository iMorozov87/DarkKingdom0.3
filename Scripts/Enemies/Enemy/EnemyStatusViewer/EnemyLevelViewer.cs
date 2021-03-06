using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelViewer : MonoBehaviour
{
    [SerializeField] private TextMesh _levelText;
    
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        _levelText.text = _enemy.Level.ToString();
    }
}
