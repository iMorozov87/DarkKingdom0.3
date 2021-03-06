using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffector : MonoBehaviour
{
    [SerializeField] private ParticlePlayer _levelUppParticles;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.LevelUpped += OnLevelUpped;
    }

    private void OnDisable()
    {
        _player.LevelUpped -= OnLevelUpped;
    }

    private void OnLevelUpped()
    {
        _levelUppParticles.PlayAllParticles();
    }
}
