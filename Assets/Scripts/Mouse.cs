using UnityEngine;

public static class Mouse
{
    private static Camera cam = Camera.main;

    public static Vector3 GetMousePosition()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        return mousePosition;
    }
}
