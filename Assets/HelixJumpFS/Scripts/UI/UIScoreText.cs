using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvents
{
    [SerializeField] private ScoreCollector scoreCollector;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText.text = scoreCollector.Score.ToString();
    }

    protected override void OnBallTriggerEnter(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            scoreText.text = scoreCollector.Score.ToString();
        }
    }
}
