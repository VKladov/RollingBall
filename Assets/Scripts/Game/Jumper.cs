using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private Rigidbody _rigidbody;

    public float JumpSpeed => _jumpForce / _rigidbody.mass;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckGrounded())
            Jump();
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.3f);
    }
}
