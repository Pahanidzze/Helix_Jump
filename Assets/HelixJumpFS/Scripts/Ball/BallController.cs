using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneTrigger
{
    private BallMovement model;
    [HideInInspector] public UnityEvent<SegmentType> EnterTrigger;
    [HideInInspector] public UnityEvent<SegmentType, Floor> EnterFloorTrigger;

    private void Start()
    {
        model = GetComponent<BallMovement>();
    }

    protected override Segment OnTriggerEnter(Collider other)
    {
        Segment segment = base.OnTriggerEnter(other);

        if (segment != null)
        {
            if (segment.Type == SegmentType.Default)
            {
                model.Jump();
            }
            else if (segment.Type == SegmentType.Empty)
            {
                model.Fall(segment.transform.position.y);
            }
            else if (segment.Type == SegmentType.Trap)
            {
                model.Stop();
            }
            else if (segment.Type == SegmentType.Finish)
            {
                model.Stop();
            }
            EnterTrigger.Invoke(segment.Type);
            EnterFloorTrigger.Invoke(segment.Type, segment.gameObject.GetComponentInParent<Floor>());
        }

        return segment;
    }
}
