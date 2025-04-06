using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public List<CardInfo> cards = new List<CardInfo>();
    private Deck deck;

    private void Awake()
    {
        deck = FindObjectOfType<Deck>();
    }

    public List<CardInfo> Get() { return cards; }

    public void Add(CardInfo cardInfo)
    {
        cards.Add(cardInfo);
    }

    public void ShuffleToDeck()
    {
        foreach (var card in cards)
        {
            deck.Add(card);
        }

        cards = new List<CardInfo>();
    }
}
