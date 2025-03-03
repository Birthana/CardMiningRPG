using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardInfo> cards = new List<CardInfo>();
    private Drop drop;

    private void Awake()
    {
        drop = FindObjectOfType<Drop>();
    }

    public CardInfo Draw()
    {
        if (cards.Count == 0)
        {
            drop.ShuffleToDeck();
        }

        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public void Add(CardInfo cardInfo)
    {
        cards.Add(cardInfo);
    }
}
