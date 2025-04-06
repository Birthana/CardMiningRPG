using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Character player;
    [SerializeField]private List<Card> cards = new List<Card>();

    private Deck deck;
    private Drop drop;
    private HandUI handUi;
    private CardSpawner cardSpawner;

    private void Awake()
    {
        deck = FindObjectOfType<Deck>();
        drop = FindObjectOfType<Drop>();
        handUi = FindObjectOfType<HandUI>();
        cardSpawner = FindObjectOfType<CardSpawner>();
    }
    
    private void Start()
    {
        DrawNewHand();
    }

    public void DrawNewHand()
    {
        DiscardHand();
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
    }

    public void Add(Character chara, CardInfo cardInfo)
    {
        if (Contains(cardInfo))
        {
            var cardInHand = GetCard(cardInfo);
            if (cardInHand != null && (cardInHand.GetInfo() is IItemCard itemCard))
            {
                itemCard.AddToStack();
                return;
            }
        }

        var newCard = cardSpawner.Spawn(chara, cardInfo, handUi.transform);
        cards.Add(newCard);
    }

    public bool Contains(CardInfo cardInfo)
    {
        foreach (var card in cards)
        {
            if (card.GetInfo().cardName.Equals(cardInfo.cardName))
            {
                return true;
            }
        }

        return false;
    }

    public void DiscardHand()
    {
        foreach (var card in cards)
        {
            drop.Add(card.GetInfo());
            Destroy(card.GetUI().gameObject);
        }

        cards = new List<Card>();
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
        Destroy(card.GetUI().gameObject);
    }

    public Card GetCard(CardUI cardUI)
    {
        foreach (var card in cards)
        {
            if (card.GetUI().Equals(cardUI))
            {
                return card;
            }
        }

        return null;
    }

    public Card GetCard(CardInfo cardInfo)
    {
        foreach (var card in cards)
        {
            if (card.GetInfo().cardName.Equals(cardInfo.cardName))
            {
                return card;
            }
        }

        return null;
    }

    public List<CardInfo> Get()
    {
        var handCards = new List<CardInfo>();
        foreach (var card in cards)
        {
            handCards.Add(card.GetInfo());
        }

        return handCards;
    }
}
