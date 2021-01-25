using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBuffer : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _capacity = 10;

    private List<Obstacle> _buffer = new List<Obstacle>();

    public bool TryGetNext(out Obstacle obstacle)
    {
        obstacle = _buffer.Find(item => item.gameObject.activeSelf == false);
        if (obstacle == null && _buffer.Count < _capacity)
        {
            obstacle = Instantiate(_obstaclePrefab);
            _buffer.Add(obstacle);
            return true;
        }

        return obstacle != null;
    }
}
