using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _ratingButton;

    [SerializeField] protected CanvasGroup GameScreen;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _ratingButton.onClick.AddListener(OnRatingButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _ratingButton.onClick.RemoveListener(OnRatingButtonClick);
    }

    protected void OnRatingButtonClick()
    {

    }

    protected abstract void OnStartButtonClick();

    public abstract void Open();

    public abstract void Close();
}
