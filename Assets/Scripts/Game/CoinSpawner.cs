using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : Spawner
{
    [SerializeField] protected float _coinSpawnDelay = 0.2f;

    public override float RandomDelayBefore => Random.Range(2, 5);

    protected override float GetSpawnDelay() => _coinSpawnDelay;
}
