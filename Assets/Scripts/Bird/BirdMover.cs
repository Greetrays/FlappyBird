using System.Collections;
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
    private bool _moveIsPosible;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        Reset();
    }

    private void Update()
    {
        if (_moveIsPosible)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.rotation = _maxRotation;
                _rigidbody.velocity = new Vector2(_speed, 0);
                _rigidbody.AddForce(Vector2.up * _speedJump, ForceMode2D.Force);
                _rigidbody.velocity = new Vector2(_speed, 0);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speedRotate * Time.deltaTime);
    }

    public void SwitchMoveIsPosible(bool moveIsPosible)
    {
        _moveIsPosible = moveIsPosible;
    }

    public void Reset()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        SwitchMoveIsPosible(true);
    }
}
