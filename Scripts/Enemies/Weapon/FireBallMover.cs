using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;
    private float _destructionDelay = 5.0F;

    private void Start()
    {
        StartCoroutine(WaitDestruction(_destructionDelay));
    }

    public void SetTarget(Vector2 target)
    {
        _target = target;
        SetDirection();
    }

    private IEnumerator WaitDestruction(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void SetDirection()
    {
        Vector3 loockDirection = _target - transform.position;
        float angle = Vector3.Angle(transform.right, loockDirection);

        if (_target.y < transform.position.y)
            angle = -angle;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
    }
}
