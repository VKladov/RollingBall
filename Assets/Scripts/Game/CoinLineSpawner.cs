using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLineSpawner : CoinSpawner
{
    protected override int GetGroupLength() => Random.Range(5, 10);
}
