using UnityEngine;

public class GUI : BallEvents
{
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject defeatPanel;

    protected override void Awake()
    {
        base.Awake();

        passedPanel.SetActive(false);
        defeatPanel.SetActive(false);
    }

    protected override void OnBallTriggerEnter(SegmentType type)
    {
        if (type == SegmentType.Finish)
        {
            passedPanel.SetActive(true);
        }
        else if (type == SegmentType.Trap)
        {
            defeatPanel.SetActive(true);
        }
    }
}
