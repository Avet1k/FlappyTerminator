using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnStartButtonClick;
        _endGameScreen.PlayButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnStartButtonClick;
        _endGameScreen.PlayButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    
    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }
}
