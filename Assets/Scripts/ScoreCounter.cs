using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    
    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
