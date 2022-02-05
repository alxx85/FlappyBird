using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private int _maxScore;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
        PlayerPrefs.Save();
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            _maxScore = PlayerPrefs.GetInt("MaxScore");
            Debug.Log(_maxScore);
        }
    }

    public void OnGameOver()
    {
        if (_bird.Score > _maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", _bird.Score);
        }
        
        _gameOverScreen.MaxScoreChanged(_maxScore);
        Time.timeScale = 0;
        _gameOverScreen.Open();

    }

    private void OnPlayButtonClick()
    {
        _startScreen.Closed();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Closed();
        _pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }
}
