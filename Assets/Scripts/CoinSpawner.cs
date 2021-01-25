using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : Spawner
{
    [SerializeField] private float _coinSpawnDelay = 0.2f;
    [SerializeField] private Jumper _player;

    private float _jumpSpeed;
    private float _arcSpawnTime;

    public UnityAction SpawnFinished;

    public void SpawnLine(int length)
    {
        StartCoroutine(SpawnLineLoop(length));
    }

    public void SpawnArc()
    {
        StartCoroutine(SpawnArcLoop());
    }

    private void Awake()
    {
        _jumpSpeed = _player.JumpSpeed;
        _arcSpawnTime = _jumpSpeed / -Physics.gravity.y * 2;
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

    private IEnumerator SpawnArcLoop()
    {
        float time = 0;
        while (time <= _arcSpawnTime)
        {
            TrySpawn(GetJumpHeight(time));
            yield return new WaitForSeconds(_coinSpawnDelay);
            time += _coinSpawnDelay;
        }

        SpawnFinished?.Invoke();
    }

    private float GetJumpHeight(float time)
    {
        return Mathf.Max(0, _jumpSpeed * time + Physics.gravity.y * time * time / 2);
    }
}
