﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    private int _score;
    private BirdMover _birdMover;

    public event UnityAction Died;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void ReserPlayer()
    {
        _score = 0;
        _birdMover.Reset();
    }

    public void Die()
    {
        Debug.Log("You died");
        Time.timeScale = 0;
    }

    public void Freeze()
    {
        _birdMover.SwitchMoveIsPosible(false);
    }

    public void AddScore()
    {
        _score++;
    }
}
