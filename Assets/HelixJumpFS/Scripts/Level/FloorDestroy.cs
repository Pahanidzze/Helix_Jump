using UnityEngine;

public class FloorDestroy : BallEvents
{
    [SerializeField] TrailCollector trailCollector;

    protected override void OnBallTriggerEnter(SegmentType type, Floor floor)
    {
        if (type == SegmentType.Empty)
        {
            floor.AnimatorSetActive(true);
            trailCollector.CleanTrails();
        }
    }
}
