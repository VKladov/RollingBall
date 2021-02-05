using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMover : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private float _visibleDistance = 10;

    private Queue<Platform> _platforms = new Queue<Platform>();
    private Vector3 _endPosition;

    private void Awake()
    {
        float totalPlatformsLength = 0;
        float platformLength = _platformPrefab.Length;
        while (totalPlatformsLength < _visibleDistance + platformLength)
        {
            Vector3 position = transform.position + Vector3.right * totalPlatformsLength;
            Platform platform = Instantiate(_platformPrefab, position, Quaternion.identity);
            _platforms.Enqueue(platform);

            totalPlatformsLength += platform.Length;
            platformLength = platform.Length;
        }

        _endPosition = transform.position + Vector3.right * totalPlatformsLength;
    }

    private void FixedUpdate()
    {
        if (transform.position.x + _visibleDistance > _endPosition.x)
            MoveFirstPlatformToEnd();
    }

    private void MoveFirstPlatformToEnd()
    {
        Platform firstPlatform = _platforms.Dequeue();
        _platforms.Enqueue(firstPlatform);

        firstPlatform.transform.position = _endPosition;
        firstPlatform.Clear();

        _endPosition = firstPlatform.EndPosition;
    }
}
