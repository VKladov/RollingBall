using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _buffer;

    public UnityAction SpawnFinished;

    public virtual float RandomDelayBefore => Random.Range(2, 3);

    public void TrySpawn(float offsetY = 0)
    {
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit hit) &&
            hit.transform.TryGetComponent(out Platform platform) &&
            _buffer.TryGetNext(out Obstacle item))
            platform.PlaceObstacle(hit.point + Vector3.up * offsetY, item);
    }

    public virtual void SpawnGroup()
    {
        TrySpawn(0);
        SpawnFinished?.Invoke();
    }
}
