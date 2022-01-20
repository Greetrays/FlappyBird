using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _bird.ChangedScore += OnChangedScore;
    }

    private void OnDisable()
    {
        _bird.ChangedScore -= OnChangedScore;
    }

    private void OnChangedScore()
    {
        _score.text = _bird.Score.ToString();
    }
}
