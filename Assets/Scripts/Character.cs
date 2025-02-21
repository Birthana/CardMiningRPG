using UnityEngine;

public class Character : MonoBehaviour
{
    public Card card;
    public int MOVE_RANGE = 5;

    private void Awake()
    {
        card.SetCharacter(this);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        card.Action();
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }
}
