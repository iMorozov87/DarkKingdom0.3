using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particlesSystems;

    public void PlayAllParticles()
    {
        foreach (var particle in _particlesSystems)
        {
            particle.Play();
        }
    }
}
