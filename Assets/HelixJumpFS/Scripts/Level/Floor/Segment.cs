using UnityEngine;

public enum SegmentType
{
    Default = 0,
    Finish = 1,
    Trap = 2,
    Empty = 3
}

[RequireComponent(typeof(MeshRenderer))]
public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;
    public SegmentType Type => type;

    [SerializeField] private Material trapMaterial;
    [SerializeField] private Material finishMaterial;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetEmpty()
    {
        type = SegmentType.Empty;
        meshRenderer.enabled = false;
    }

    public void SetTrap()
    {
        type = SegmentType.Trap;
        meshRenderer.enabled = true;
        meshRenderer.material = trapMaterial;
    }

    public void SetFinish()
    {
        type = SegmentType.Finish;
        meshRenderer.enabled = true;
        meshRenderer.material = finishMaterial;
    }
}
