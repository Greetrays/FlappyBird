using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdCollisionHendler : MonoBehaviour
{
    private Bird _player;

    private void Start()
    {
        _player = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone score))
            _player.AddScore();
        else
            _player.Die();
    }
}
