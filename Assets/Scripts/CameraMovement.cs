using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float OFFSET;
    public float SPEED;
    public Camera cam;
    public Mouse mouse;

    private void Awake()
    {
        mouse = new Mouse(cam);
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        if (mousePosition.x < OFFSET)
        {
            Move(Vector3.left);
        }

        if (mousePosition.x > Screen.width - OFFSET)
        {
            Move(Vector3.right);
        }

        if (mousePosition.y < OFFSET)
        {
            Move(Vector3.down);
        }

        if (mousePosition.y > Screen.height - OFFSET)
        {
            Move(Vector3.up);
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * SPEED * Time.deltaTime;
    }
}
