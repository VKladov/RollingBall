using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectsPlacer : MonoBehaviour
{
    [SerializeField] private Spawner _barrierSpawner;
    [SerializeField] private CoinSpawner _coinSpawner;

    private void OnEnable()
    {
        _coinSpawner.SpawnFinished += StartNextRandomAction;
    }

    private void Start()
    {
        StartNextRandomAction();
    }

    private IEnumerator SpawnCoinsArcAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        _coinSpawner.SpawnArc();
    }

    private IEnumerator SpawnCoinsLineAfter(float delay, int length)
    {
        yield return new WaitForSeconds(delay);
        _coinSpawner.SpawnLine(length);
    }

    private IEnumerator SpawnObstacle(float delay)
    {
        yield return new WaitForSeconds(delay);
        _barrierSpawner.TrySpawn();
        StartNextRandomAction();
    }

    private void StartNextRandomAction()
    {
        int nextActionIndex = Random.Range(0, 4);
        switch (nextActionIndex)
        {
            case 0:
                StartCoroutine(SpawnCoinsArcAfter(Random.Range(2, 5)));
                break;
            case 1:
                StartCoroutine(SpawnCoinsLineAfter(Random.Range(2, 5), Random.Range(5, 10)));
                break;
            default:
                StartCoroutine(SpawnObstacle(Random.Range(2, 3)));
                break;
        }
    }
}
