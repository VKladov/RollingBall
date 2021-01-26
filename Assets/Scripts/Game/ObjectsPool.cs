using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _capacity = 10;

    private List<Obstacle> _pool = new List<Obstacle>();

    public bool TryGetNext(out Obstacle obstacle)
    {
        obstacle = _pool.Find(item => item.gameObject.activeSelf == false);
        if (obstacle == null && _pool.Count < _capacity)
        {
            obstacle = Instantiate(_obstaclePrefab);
            _pool.Add(obstacle);
            return true;
        }

        return obstacle != null;
    }
}
