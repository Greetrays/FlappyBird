﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedJump;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Vector2 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = _maxRotation;
            _rigidbody.velocity = new Vector2(_speed, 0);
            _rigidbody.AddForce(Vector2.up * _speedJump, ForceMode2D.Force);
            _rigidbody.velocity = new Vector2(_speed, 0);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotate * Time.deltaTime);
    }
}