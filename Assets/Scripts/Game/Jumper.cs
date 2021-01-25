using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private Rigidbody _rigidbody;

    private bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 0.3f);

    public float JumpSpeed => _jumpForce / _rigidbody.mass;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded)
            Jump();
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
