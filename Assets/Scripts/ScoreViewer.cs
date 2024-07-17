using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    
    private TMP_Text _label;

    private void Awake()
    {
        _label = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ChangeView;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ChangeView;
    }
    
    private void ChangeView(int score)
    {
        _label.text = score.ToString();
    }
}
