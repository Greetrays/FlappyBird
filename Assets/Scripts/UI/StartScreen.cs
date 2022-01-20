using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction _started;

    public override void Close()
    {
        GameScreen.alpha = 0;
        GameScreen.interactable = false;
        GameScreen.blocksRaycasts = false;
    }

    public override void Open()
    {
        GameScreen.alpha = 1;
        GameScreen.interactable = true;
        GameScreen.blocksRaycasts = true;
    }

    protected override void OnStartButtonClick()
    {
        _started?.Invoke();
    }
}
