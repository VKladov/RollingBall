using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    public float Length { get; private set; }

    public Vector3 EndPosition => transform.position + Vector3.right * Length;

    private void Awake()
    {
        Length = GetComponent<BoxCollider>().size.x;
    }
}
