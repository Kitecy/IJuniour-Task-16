using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.Changed += ShowScore;
    }

    private void OnDisable()
    {
        _score.Changed -= ShowScore;
    }

    private void ShowScore(int score)
    {
        _text.text = score.ToString();
    }
}
