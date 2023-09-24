using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image fillProgressBar;

    private void Start()
    {
        currentLevelText.text = levelProgress.CurrentLevel.ToString();
        nextLevelText.text = (levelProgress.CurrentLevel + 1).ToString();
        fillProgressBar.fillAmount = 0;
    }

    protected override void OnBallTriggerEnter(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            fillProgressBar.fillAmount += FillAmountStep();
        }
    }

    private float FillAmountStep()
    {
        return 1f / (levelGenerator.RealFloorAmount() - 1);
    }
}
