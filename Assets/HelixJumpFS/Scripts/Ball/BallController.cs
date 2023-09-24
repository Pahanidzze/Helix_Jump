using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : MonoBehaviour
{
    private BallMovement model;
    [HideInInspector] public UnityEvent<SegmentType> EnterTrigger;
    [HideInInspector] public UnityEvent<SegmentType, Floor> EnterFloorTrigger;

    private void Start()
    {
        model = GetComponent<BallMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Segment segment) == false) return;

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
}
