using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMover : MonoBehaviour
{
    [SerializeField] private Platform _firstPlatform;
    [SerializeField] private float _visibleDistance = 10;
    [SerializeField] private float _initialSpeed = 5;
    [SerializeField] private float _acceleration = 0.2f;

    private float _speed;
    private List<Platform> _platforms = new List<Platform>();
    private int _lastPlatformIndex;

    private void Start()
    {
        _speed = _initialSpeed;
        _firstPlatform.transform.position = transform.position;
        _platforms.Add(_firstPlatform);

        while(_platforms[_platforms.Count - 1].EndPosition.x < transform.position.x + _visibleDistance + _firstPlatform.Length)
            _platforms.Add(Instantiate(_firstPlatform, _platforms[_platforms.Count - 1].EndPosition, Quaternion.identity));

        _lastPlatformIndex = _platforms.Count - 1;
    }

    private void FixedUpdate()
    {
        Vector3 move = Vector3.left * _speed * Time.deltaTime;
        foreach (Platform platform in _platforms)
            platform.transform.position += move;

        if (_platforms[_lastPlatformIndex].EndPosition.x < transform.position.x + _visibleDistance)
            MoveFirstPlatformToEnd();

        _speed += _acceleration * Time.deltaTime;
    }

    private void MoveFirstPlatformToEnd()
    {
        Vector3 position = _platforms[_lastPlatformIndex].EndPosition;
        _lastPlatformIndex = (_lastPlatformIndex + 1) % _platforms.Count;
        _platforms[_lastPlatformIndex].transform.position = position;
        _platforms[_lastPlatformIndex].Clear();
    }
}
