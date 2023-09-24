using UnityEngine;
using UnityEngine.UI;

public class UIHighScoreText : BallEvents
{
    [SerializeField] private ScoreCollector scoreCollector;
    [SerializeField] private Text highScoreText;

    private void Start()
    {
        highScoreText.text = scoreCollector.HighScore.ToString();
    }
}
