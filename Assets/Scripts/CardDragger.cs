using UnityEngine;
using UnityEngine.UI;

public class CardDragger : MonoBehaviour
{
    private Card pickUp;

    private Hand hand;
    private HandUI handUI;
    private Mouse mouse;
    private Ground ground;
    private RangeIndicator rangeIndicator;
    private Drop drop;

    private void Awake()
    {
        hand = FindObjectOfType<Hand>();
        handUI = FindObjectOfType<HandUI>();
        mouse = new Mouse(Camera.main);
        ground = FindObjectOfType<Ground>();
        rangeIndicator = FindObjectOfType<RangeIndicator>();
        drop = FindObjectOfType<Drop>();
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
        if (!Input.GetMouseButtonDown(0) || pickUp != null)
        {
            return;
        }

        var hit = Raycast.GetHitAtMouse();
        if (hit)
        {
            var cardUI = hit.collider.GetComponent<CardUI>();
            if (cardUI == null)
            {
                return;
            }

            pickUp = hand.GetCard(cardUI);
            DisplayRangeIndicator();
        }
    }

    private void DisplayRangeIndicator()
    {
        if (pickUp == null)
        {
            return;
        }

        var cardInfo = pickUp.GetInfo();
        if (cardInfo is not IHasRange)
        {
            return;
        }

        ((IHasRange)cardInfo).SpawnIndicator(rangeIndicator);
    }

    private void MovePickUpWithMouse()
    {
        if (pickUp == null)
        {
            return;
        }

        pickUp.SetUIPosition(mouse.GetMousePosition());
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

        LayoutRebuilder.ForceRebuildLayoutImmediate(handUI.GetComponent<RectTransform>());
        pickUp = null;
        rangeIndicator.Despawn();
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
        if ((cardInfo is IActionCard && !((IActionCard)cardInfo).CanPlay(mouse, ground, rangeIndicator)) ||
            cardInfo is not IActionCard)
        {
            return;
        }

        pickUp.Action(mouse, ground);
        hand.Remove(pickUp);
        drop.Add(cardInfo);
        pickUp = null;
        rangeIndicator.Despawn();
    }
}
