using UnityEngine;

public class OneTrigger : MonoBehaviour
{
    private bool stuck = false;

    protected virtual Segment OnTriggerEnter(Collider other)
    {
        if (stuck == true) return null;
        if (other.TryGetComponent(out Segment segment) == false) return null;
            
        stuck = true;
        return segment;
    }

    private void OnTriggerExit(Collider other)
    {
        if (stuck == false) return;
        if (other.TryGetComponent(out Segment _) == false) return;

        stuck = false;
    }
}
