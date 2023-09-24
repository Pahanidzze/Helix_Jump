using UnityEngine;

public class InputManager : BallEvents
{
    [SerializeField] private MouseRotator mouseRotator;

    protected override void OnBallTriggerEnter(SegmentType type) 
    {
        if (type == SegmentType.Finish || type == SegmentType.Trap) mouseRotator.enabled = false;
    }
}
