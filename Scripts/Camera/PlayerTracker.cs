using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _coefficientOffset = 3;
    [SerializeField] private Transform _leftUpperBorderCamera;
    [SerializeField] private Transform _rightLowerBorderCamera;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private PlayerMover _player;
    private float _constantAxisZ = -10;
    private Camera _camera;
    private Vector3 _currentPosition;
    private Vector3 _targetPosition;
    private Vector2 _directionMovement;
    private float _minHeightMovement;
    private float _maxHeightMovement;
    private float _minWidthMovement;
    private float _maxWidthMovement;

    private void Awake()
    {
        _player = _playerSpawner.GetPlayer().GetComponent<PlayerMover>();
        _camera = GetComponent<Camera>();
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }

    private void Start()
    {
        _minHeightMovement = _rightLowerBorderCamera.position.y;
        _maxHeightMovement = _leftUpperBorderCamera.position.y;
        _minWidthMovement = _leftUpperBorderCamera.position.x;
        _maxWidthMovement = _rightLowerBorderCamera.position.x;
    }

    private void LateUpdate()
    {
        _directionMovement = _player.DirectionMovement;
        _currentPosition = transform.position;
        _targetPosition = _player.transform.position + new Vector3(_directionMovement.x * _coefficientOffset, _directionMovement.y * _coefficientOffset, _constantAxisZ);

        _targetPosition.x = Mathf.Clamp(_targetPosition.x, _minWidthMovement, _maxWidthMovement);
        _targetPosition.y = Mathf.Clamp(_targetPosition.y, _minHeightMovement, _maxHeightMovement);

        transform.position = Vector3.Lerp(_currentPosition, _targetPosition, _speed * Time.deltaTime);
    }
}




