using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    private List<Obstacle> _obstacles = new List<Obstacle>();

    public float Length { get; private set; }

    public Vector3 EndPosition => transform.position + Vector3.right * Length;

    private void Awake()
    {
        Length = GetComponent<BoxCollider>().size.x;
    }

    public void PlaceObstacle(Vector3 position, Obstacle obstacle)
    {
        _obstacles.Add(obstacle);
        obstacle.Deactivated += OnDeactivated;
        obstacle.Activate();

        obstacle.transform.position = position;
        obstacle.transform.parent = transform;
    }

    public void Clear()
    {
        for (int i = 0; i < _obstacles.Count; i++)
            _obstacles[i].Deactivate();
    }

    private void OnDeactivated(Obstacle obstacle)
    {
        obstacle.Deactivated -= OnDeactivated;
        _obstacles.Remove(obstacle);
    }
}
