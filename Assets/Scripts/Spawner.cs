using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsBuffer _buffer;

    public void TrySpawn(float offsetY = 0)
    {
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit hit) &&
            hit.transform.TryGetComponent(out Platform platform) &&
            _buffer.TryGetNext(out Obstacle item))
            platform.PlaceObstacle(hit.point + Vector3.up * offsetY, item);
    }
}
