using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArcSpawner : CoinSpawner
{
    [SerializeField] private Jumper _player;

    private float _jumpSpeed;
    private int _arcLength;

    private void Awake()
    {
        _jumpSpeed = _player.JumpSpeed;
        float arcSpawnTime = _jumpSpeed / -Physics.gravity.y * 2;
        _arcLength = (int)(arcSpawnTime / _coinSpawnDelay) + 1;
    }

    protected override float GetYOffset(int index)
    {
        return GetJumpHeight(index * GetSpawnDelay());
    }

    protected override int GetGroupLength() => _arcLength;

    private float GetJumpHeight(float time)
    {
        return Mathf.Max(0, _jumpSpeed * time + Physics.gravity.y * time * time / 2);
    }
}
