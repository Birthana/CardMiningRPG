using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Card pickUp;
    private Vector3 previousPosition;

    private Hand hand;
    private Mouse mouse;
    private Ground ground;

    private void Awake()
    {
        hand = FindObjectOfType<Hand>();
        mouse = new Mouse(Camera.main);
        ground = FindObjectOfType<Ground>();
    }

    private void Update()
    {
        TryToPickUp();
        MovePickUpWithMouse();
        TryToCast();
        ReturnPickUp();
    }

    private void TryToPickUp()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var hit = Physics2D.Raycast(new Mouse(Camera.main).GetMousePosition(), Vector2.zero);
        if (hit)
        {
            pickUp = hit.collider.GetComponent<Card>();
            previousPosition = pickUp.transform.position;
        }
    }

    private void MovePickUpWithMouse()
    {
        if (pickUp == null)
        {
            return;
        }

        pickUp.transform.position = mouse.GetMousePosition();
    }

    private void ReturnPickUp()
    {
        if (pickUp == null)
        {
            return;
        }

        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        pickUp.transform.position = previousPosition;
        pickUp = null;
        previousPosition = Vector3.zero;
    }

    private void TryToCast()
    {
        if (pickUp == null)
        {
            return;
        }

        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        var cardInfo = pickUp.GetInfo();
        if (cardInfo is IActionCard && !((IActionCard)cardInfo).CanPlay(mouse, ground))
        {
            return;
        }

        pickUp.Action(mouse, ground);
        hand.Remove(pickUp);
        pickUp = null;
    }
}
