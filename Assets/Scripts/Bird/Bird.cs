using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    [SerializeField] private UnityEvent _changedScoreAudio;

    private int _score;
    private BirdMover _birdMover;

    public event UnityAction Died;
    public event UnityAction ChangedScore;

    public int Score => _score;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _score = 0;
        ChangedScore?.Invoke();
        _birdMover.Reset();
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void Freeze()
    {
        _birdMover.SwitchMoveIsPosible(false);
    }

    public void AddScore()
    {
        _score++;
        ChangedScore?.Invoke();
        _changedScoreAudio?.Invoke();
    }
}
