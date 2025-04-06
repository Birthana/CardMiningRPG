using UnityEngine;
using UnityEngine.UI;

public class CardDragger : MonoBehaviour
{
    private Card pickUp;

    private Hand hand;
    private HandUI handUI;
    private Ground ground;
    private RangeIndicator rangeIndicator;
    private Drop drop;

    private void Awake()
    {
        hand = FindObjectOfType<Hand>();
        handUI = FindObjectOfType<HandUI>();
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
        if (!hit)
        {
            return;
        }

        var card = PickUpHandCard(hit);
        if (card == null)
        {
            return;
        }

        pickUp = card;
        DisplayRangeIndicator();
    }

    private Card PickUpHandCard(RaycastHit2D hit)
    {
        var cardUI = hit.collider.GetComponent<CardUI>();
        if (cardUI == null)
        {
            return null;
        }

        return hand.GetCard(cardUI);
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

        pickUp.SetUIPosition(Mouse.GetMousePosition());
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

        if (CanNotCast(pickUp))
        {
            return;
        }

        pickUp.Action(ground);
        rangeIndicator.Despawn();
        AfterCast();
    }

    private bool CanNotCast(Card card)
    {
        var cardInfo = card.GetInfo();
        return ActionCardInNotRange(cardInfo) || cardInfo is not IActionCard;
    }

    private bool ActionCardInNotRange(CardInfo cardInfo)
    {
        return cardInfo is IActionCard && !((IActionCard)cardInfo).CanPlay(ground, rangeIndicator);
    }

    private void AfterCast()
    {
        hand.Remove(pickUp);
        drop.Add(pickUp.GetInfo());
        pickUp = null;
    }
}
