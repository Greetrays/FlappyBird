using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipesGenerator _pipesGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen._started += OnStartButtonClick;
        _gameOverScreen._restarted += OnRestartButtonClick;
        _bird.Died += OnDied;
    }

    private void OnDisable()
    {
        _startScreen._started -= OnStartButtonClick;
        _gameOverScreen._restarted -= OnRestartButtonClick;
        _bird.Died -= OnDied;
    }

    private void Start()
    {
        _startScreen.Open();
        _gameOverScreen.Close();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipesGenerator.Reset();
        StartGame();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _bird.ResetPlayer();
        Time.timeScale = 1;
    }

    private void OnDied()
    {
        Debug.Log(1);
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }
}
