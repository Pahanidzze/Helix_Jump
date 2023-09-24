using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private List<Segment> defaultSegments;

    private void Awake()
    {
        defaultSegments = new List<Segment>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Segment segment) == false) continue;
            defaultSegments.Add(segment);
        }
    }

    public void AddEmptySegments(int amount)
    {
        if (amount > defaultSegments.Count) return;
        for (int i = 0; i < amount; i++)
        {
            defaultSegments[0].SetEmpty();
            defaultSegments.RemoveAt(0);
        }
    }

    public void AddRandomTrapSegments(int amount)
    {
        if (amount > defaultSegments.Count) return;
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, defaultSegments.Count - 1);
            defaultSegments[index].SetTrap();
            defaultSegments.RemoveAt(index);
        }
    }

    public void SetRandomRotation()
    {
        transform.Rotate(0, Random.Range(0f, 360f), 0);
    }

    public void SetAllFinishSegments()
    {
        int amount = defaultSegments.Count;
        for (int i = 0; i < amount; i++)
        {
            defaultSegments[0].SetFinish();
            defaultSegments.RemoveAt(0);
        }
    }

    public void AnimatorSetActive(bool active)
    {
        if (TryGetComponent(out Animator animator) == false) return;
        animator.enabled = active;
    }
}
