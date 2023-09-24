using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] private BallController ballController;

    protected virtual void Awake()
    {
        ballController.EnterTrigger.AddListener(OnBallTriggerEnter);
        ballController.EnterFloorTrigger.AddListener(OnBallTriggerEnter);
    }

    private void OnDestroy()
    {
        ballController.EnterTrigger.RemoveListener(OnBallTriggerEnter);
        ballController.EnterFloorTrigger.RemoveListener(OnBallTriggerEnter);
    }

    protected virtual void OnBallTriggerEnter(SegmentType type) { }
    protected virtual void OnBallTriggerEnter(SegmentType type, Floor floor) { }
}
