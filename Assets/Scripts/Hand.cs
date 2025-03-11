using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Character player;
    public CardUI cardUIPrefab;
    [SerializeField]private List<Card> cards = new List<Card>();

    private Deck deck;
    private Drop drop;
    private HandUI handUi;

    private void Awake()
    {
        deck = FindObjectOfType<Deck>();
        drop = FindObjectOfType<Drop>();
        handUi = FindObjectOfType<HandUI>();
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
        var newCardUI = Instantiate(cardUIPrefab, handUi.transform);
        var newCard = new Card(chara, cardInfo, newCardUI);
        cards.Add(newCard);
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
}
