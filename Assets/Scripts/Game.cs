using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
    }
}
