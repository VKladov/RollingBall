using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArcSpawner : CoinSpawner
{
    [SerializeField] private Jumper _player;

    private float _jumpSpeed;
    private int _arcLength;

    public override void SpawnGroup()
    {
        StartCoroutine(SpawnArcLoop());
    }

    private void Awake()
    {
        _jumpSpeed = _player.JumpSpeed;
        float arcSpawnTime = _jumpSpeed / -Physics.gravity.y * 2;
        _arcLength = (int)(arcSpawnTime / _coinSpawnDelay) + 1;
    }

    private IEnumerator SpawnArcLoop()
    {
        float time = 0;
        for (int i = 0; i < _arcLength; i++)
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
