using UnityEngine;

public class Mouse
{
    private Camera cam;

    public Mouse(Camera camera)
    {
        cam = camera;
    }

    public Vector3 GetMousePosition()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        return mousePosition;
    }
}
