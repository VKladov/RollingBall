using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float offsetX = 2;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x + offsetX, transform.position.y, transform.position.z);
    }
}
