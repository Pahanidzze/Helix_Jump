using UnityEngine;

public class ScoreCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;

    private int score = 0;
    public int Score => score;
    private int highScore = 0;
    public int HighScore => highScore;

    private int bonusCounter = 0;

    protected override void Awake()
    {
        base.Awake();
        Load();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3) == true)
        {
            ResetHighScore();
        }
    }
#endif

    protected override void OnBallTriggerEnter(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            score += levelProgress.CurrentLevel + bonusCounter;
            bonusCounter++;
        }
        else if ((type == SegmentType.Finish || type == SegmentType.Trap) && score > highScore)
        {
            highScore = score;
            Save();
        }
        else if (type == SegmentType.Default)
        {
            bonusCounter = 0;
        }
    }

#if UNITY_EDITOR
    private void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("ScoreCollector:HighScore");
    }
#endif

    private void Save()
    {
        PlayerPrefs.SetInt("ScoreCollector:HighScore", highScore);
    }

    private void Load()
    {
        highScore = PlayerPrefs.GetInt("ScoreCollector:HighScore", 0);
    }
}
