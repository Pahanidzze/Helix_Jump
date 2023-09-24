using UnityEngine;

public class FloorAnimationController : BallEvents
{
    protected override void OnBallTriggerEnter(SegmentType type, Floor floor)
    {
        if (type == SegmentType.Empty)
        {
            floor.AnimatorSetActive(true);
        }
    }
}
