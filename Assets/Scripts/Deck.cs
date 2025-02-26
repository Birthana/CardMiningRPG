using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardInfo> cards = new List<CardInfo>();

    public CardInfo Draw()
    {
        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
