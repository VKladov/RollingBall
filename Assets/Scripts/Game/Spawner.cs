using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;
    [SerializeField] private PlatformsMover _platformMover;

    public UnityAction SpawnFinished;

    public virtual float RandomDelayBefore => Random.Range(2, 3);

    public virtual void SpawnGroup()
    {
        TrySpawn();
        SpawnFinished?.Invoke();
    }

    protected void TrySpawn(float offsetY = 0)
    {
        if (_platformMover.TryGetPlatform(transform.position, out Platform platform))
        {
            if (_pool.TryGetNext(out Obstacle item))
            {
                Vector3 position = new Vector3(transform.position.x, platform.transform.position.y + offsetY, transform.position.z);
                platform.PlaceObstacle(position, item);
            }
        }
    }
}
