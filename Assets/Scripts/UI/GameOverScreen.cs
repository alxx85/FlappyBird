using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _exitButton;

    public event UnityAction RestartButtonClick;

    public override void Closed()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        _exitButton.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        _exitButton.interactable = true;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

}
