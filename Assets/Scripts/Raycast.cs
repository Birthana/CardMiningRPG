using UnityEngine;

public static class Raycast
{
    public static RaycastHit2D GetHitAtMouse()
    {
        return Physics2D.Raycast(Mouse.GetMousePosition(), Vector2.zero);
    }

    public static RaycastHit2D[] GetHitsAt(Vector3 position)
    {
        return Physics2D.RaycastAll(position, Vector2.zero);
    }

    public static bool HitsContain<Type>(Vector3 position)
    {
        var hits = GetHitsAt(position);
        foreach (var hit in hits)
        {
            if (hit.transform.GetComponent<Type>() != null)
            {
                return true;
            }
        }

        return false;
    }
}
