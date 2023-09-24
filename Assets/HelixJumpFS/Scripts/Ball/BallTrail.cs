using UnityEngine;

public class BallTrail : BallEvents
{
    [SerializeField] GameObject blotPrefub;
    [SerializeField] Transform ball;
    [SerializeField] Material ballMaterial;
    [SerializeField] Transform level;

    private void Start()
    {
        if (blotPrefub.TryGetComponent(out SpriteRenderer blotSpriteRenderer) == false) return;
        blotSpriteRenderer.color = ballMaterial.color;
    }

    protected override void OnBallTriggerEnter(SegmentType type)
    {
        if (type == SegmentType.Default)
        {
            BlotSpawn();
        }
    }

    private void BlotSpawn()
    {
        Vector3 blotPosition = new(ball.position.x, ball.position.y + 0.51f, ball.position.z);
        GameObject currentBlot = Instantiate(blotPrefub, blotPosition, blotPrefub.transform.rotation, level);
        currentBlot.transform.Rotate(0, 0, Random.Range(0f, 360f));
    }
}
