using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAfterStunTransition : Transition
{
    [SerializeField] private float _duratin;

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(GoThroughTime(_duratin));
    }

    private IEnumerator GoThroughTime( float time)
    {
        yield return new WaitForSeconds(time);
        NeedTransite = true;
    }
}
