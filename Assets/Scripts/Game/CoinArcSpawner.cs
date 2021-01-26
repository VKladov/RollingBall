using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArcSpawner : CoinSpawner
{
    [SerializeField] private Jumper _player;

    private float _jumpSpeed;
    private float _arcSpawnTime;

    public override void SpawnGroup()
    {
        StartCoroutine(SpawnArcLoop());
    }

    private void Awake()
    {
        _jumpSpeed = _player.JumpSpeed;
        _arcSpawnTime = _jumpSpeed / -Physics.gravity.y * 2;
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
