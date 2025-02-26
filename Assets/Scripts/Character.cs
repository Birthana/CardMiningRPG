using UnityEngine;

public class Character : MonoBehaviour
{
    public int MOVE_RANGE = 5;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }
}
