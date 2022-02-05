using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _bestScore;

    public event UnityAction RestartButtonClick;

    public override void Closed()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        _exitButton.interactable = false;
        _exitButton.image.raycastTarget = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        _exitButton.interactable = true;
        _exitButton.image.raycastTarget = true;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void MaxScoreChanged(int maxScore)
    {
        _bestScore.text = maxScore.ToString();
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
