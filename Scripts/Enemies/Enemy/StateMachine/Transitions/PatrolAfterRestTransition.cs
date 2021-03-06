using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAfterRestTransition : Transition
{
    [SerializeField] private float _delayTime = 2.0F;

    private float _elapsedTime = 0;

    private void Update()
    {
        if (_elapsedTime <= _delayTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            NeedTransite = true;
            _elapsedTime = 0;
        }
    }
}
