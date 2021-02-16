using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 5;
    [SerializeField] private float _acceleration = 0.2f;

    private float _speed;

    private void Awake()
    {
        _speed = _initialSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
        _speed += _acceleration * Time.deltaTime;
    }
}
