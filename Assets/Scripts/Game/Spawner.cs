using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;
    [SerializeField] private PlatformsMover _platformMover;

    public UnityAction SpawnFinished;

    public virtual float RandomDelayBefore => Random.Range(2, 3);

    public void SpawnGroup()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        int length = GetGroupLength();
        for (int i = 0; i < length; i++)
        {
            TrySpawn(GetYOffset(i));
            yield return new WaitForSeconds(GetSpawnDelay());
        }
        SpawnFinished?.Invoke();
    }

    protected abstract float GetSpawnDelay();

    protected virtual int GetGroupLength() => 1;

    protected virtual float GetYOffset(int index) => 0;

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
