using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    [SerializeField] private float _playerSpeedMove;
    [SerializeField] private float _playerSpeedRotation;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, moveHorizontal * _playerSpeedRotation, 0.0f, Space.Self);
        _rigidbody.AddForce(transform.forward * _playerSpeedMove * moveVertical);
    }
}
