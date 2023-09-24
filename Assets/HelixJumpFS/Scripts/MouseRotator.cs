using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private string inputAxis;
    [SerializeField] [Min(0)] private float sensitivity;

    private void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            transform.Rotate(0, Input.GetAxis(inputAxis) * -sensitivity, 0);
        }
    }
}
