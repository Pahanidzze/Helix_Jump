using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] [Min(0)] private float fallSpeedInitial;
    [SerializeField] [Min(0)] private float fallSpeedAccelerate;
    [SerializeField] [Min(0)] private float fallDistance;
    private float fallSpeed;
    private float floorY;
    private Animator animator;
    private bool falling = false;

    private void Start()
    {
        enabled = false;
        animator = GetComponent<Animator>();
        fallSpeed = fallSpeedInitial;
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, -fallSpeed * Time.deltaTime, 0));
        fallSpeed += fallSpeedAccelerate * Time.deltaTime;
        if (transform.position.y <= floorY + fallDistance * 0.1f)
        {
            falling = false;
        }
        if (transform.position.y <= floorY)
        {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            enabled = false;
        }
    }

    public void Jump()
    {
        if (falling == true) return;
        animator.speed = 1;
        fallSpeed = fallSpeedInitial;
    }

    public void Fall(float startFloorY)
    {
        animator.speed = 0;
        enabled = true;
        floorY = startFloorY - fallDistance;
        falling = true;
    }

    public void Stop()
    {
        if (falling == true) return;
        animator.speed = 0;
    }
}
