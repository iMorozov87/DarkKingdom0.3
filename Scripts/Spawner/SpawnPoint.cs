using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    [SerializeField] protected bool _isLopping = true;
    [SerializeField] protected float _timeToActivation = 120F;

    protected List<GameObject> _listSpawnObject;

    public abstract void Init();

    public abstract void Init(Quest quest);
}
