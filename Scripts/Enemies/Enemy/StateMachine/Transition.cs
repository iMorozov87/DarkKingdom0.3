using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
        [SerializeField] private State _targetState;

        protected Player Target { get; private set; }

        public State TargetState => _targetState;
        public bool NeedTransite { get; protected set; }

        public virtual void OnEnable()
        {
            NeedTransite = false;
        }
}
