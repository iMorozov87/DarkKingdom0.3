using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _levelUppSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.LevelUpped += OnLevelUpSound;

    }
    private void OnDisable()
    {
        _player.LevelUpped -= OnLevelUpSound;
    }

    private void OnLevelUpSound()
    {
        _audioSource.PlayOneShot(_levelUppSound);
    }
}
