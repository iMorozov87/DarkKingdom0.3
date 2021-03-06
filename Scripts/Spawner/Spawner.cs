using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform[] _spawnPoints;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
            _spawnPoints[i].GetComponent<SpawnPoint>().Init();
        }
    }
}
