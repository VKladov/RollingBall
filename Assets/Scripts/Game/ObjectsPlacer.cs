using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPlacer : MonoBehaviour
{
    [SerializeField] private Spawner _barrierSpawner;
    [SerializeField] private CoinLineSpawner _coinLineSpawner;
    [SerializeField] private CoinArcSpawner _coinArcSpawner;

    private List<Spawner> _spawners;

    private void OnEnable()
    {
        _barrierSpawner.SpawnFinished += StartNextRandomAction;
        _coinLineSpawner.SpawnFinished += StartNextRandomAction;
        _coinArcSpawner.SpawnFinished += StartNextRandomAction;
    }

    private void OnDisable()
    {
        _barrierSpawner.SpawnFinished -= StartNextRandomAction;
        _coinLineSpawner.SpawnFinished -= StartNextRandomAction;
        _coinArcSpawner.SpawnFinished -= StartNextRandomAction;
    }

    private void Start()
    {
        _spawners = new List<Spawner>
        {
            _barrierSpawner,
            _barrierSpawner,
            _barrierSpawner,
            _coinArcSpawner,
            _coinLineSpawner
        };

        StartNextRandomAction();
    }

    private void StartNextRandomAction()
    {
        Spawner nextSpawner = _spawners[Random.Range(0, _spawners.Count)];
        StartCoroutine(SpawnAfter(nextSpawner.RandomDelayBefore, nextSpawner));
    }

    private IEnumerator SpawnAfter(float delay, Spawner spawner)
    {
        yield return new WaitForSeconds(delay);
        spawner.SpawnGroup();
    }
}
