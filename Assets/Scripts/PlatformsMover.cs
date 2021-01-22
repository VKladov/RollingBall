using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMover : MonoBehaviour
{
    [SerializeField] private Platform _firstPlatform;
    [SerializeField] private float _visibleDistance = 10;
    [SerializeField] private float _speed = 2;

    private List<Platform> _platforms = new List<Platform>();

    private int _lastPlatformIndex;

    private void Start()
    {
        _firstPlatform.transform.position = transform.position;
        _platforms.Add(_firstPlatform);

        while(_platforms[_platforms.Count - 1].EndPosition.x < transform.position.x + _visibleDistance + _firstPlatform.Length)
            _platforms.Add(Instantiate(_firstPlatform, _platforms[_platforms.Count - 1].EndPosition, Quaternion.identity));

        _lastPlatformIndex = _platforms.Count - 1;
    }

    private void FixedUpdate()
    {
        foreach (Platform platform in _platforms)
            platform.transform.position += Vector3.left * _speed * Time.deltaTime;

        if (_platforms[_lastPlatformIndex].EndPosition.x < transform.position.x + _visibleDistance)
            MoveFirstPlatformToEnd();
    }

    private void MoveFirstPlatformToEnd()
    {
        Vector3 position = _platforms[_lastPlatformIndex].EndPosition;
        _lastPlatformIndex = (_lastPlatformIndex + 1) % _platforms.Count;
        _platforms[_lastPlatformIndex].transform.position = position;
    }
}
