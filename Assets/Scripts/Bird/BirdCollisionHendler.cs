using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(AudioSource))]

public class BirdCollisionHendler : MonoBehaviour
{
    [SerializeField] private AudioClip _hit;

    private AudioSource _audioSource;
    private bool _isHitPlay;
    private Bird _player;

    private void Start()
    {
        _isHitPlay = false;
        _audioSource = GetComponent<AudioSource>();
        _player = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone score))
        {
            _player.AddScore();
        }
        else if (collision.TryGetComponent(out Pipes pipes))
        {
            TryPlayHit();
            _player.Freeze();
        }
        else if (collision.TryGetComponent(out Ground ground))
        {
            TryPlayHit();
            _player.Die();
            Time.timeScale = 0;
            _isHitPlay = false;
        }
    }

    private void TryPlayHit()
    {
        if (_isHitPlay == false)
        {
            _audioSource.PlayOneShot(_hit);
            _isHitPlay = true;
        }
    }
}
