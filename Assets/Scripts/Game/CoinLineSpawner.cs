using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLineSpawner : CoinSpawner
{
    public override void SpawnGroup()
    {
        StartCoroutine(SpawnLineLoop(Random.Range(5, 10)));
    }

    private IEnumerator SpawnLineLoop(int length)
    {
        for (int i = 0; i < length; i++)
        {
            TrySpawn();
            yield return new WaitForSeconds(_coinSpawnDelay);
        }

        SpawnFinished?.Invoke();
    }
}
