using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _target;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    public void SetTarget(Vector2 target)
    {
        _target = target;
        SetDirection();
    }

    private void SetDirection()
    { 
        //int maxMovement = 1;
        //Vector2 distance= (Vector2)(_target- transform.position);
        //_direction.x = distance.x / (Math.Max(Mathf.Abs(distance.x), Mathf.Abs(distance.y)));
        //_direction.y = distance.y / (Math.Max(Mathf.Abs(distance.x), Mathf.Abs(distance.y)));
        //_movement = Vector2.ClampMagnitude(_direction, maxMovement);

        Vector3 loockDirection = _target - transform.position;
     
        float angle = Vector3.Angle(transform.right, loockDirection );

        if (_target.y < transform.position.y)
            angle = -angle;

        transform.rotation = Quaternion.Euler(0,0,angle);

    }

    private void Update()
    { 
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);        
    }
}
