using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Character player;
    public Card cardPrefab;
    public float SPACING;
    private List<Card> cards = new List<Card>();
    private Deck deck;

    private void Awake()
    {
        deck = FindObjectOfType<Deck>();
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
        Add(player, deck.Draw());
    }

    public void Add(Character chara, CardInfo cardInfo)
    {
        var newCard = Instantiate(cardPrefab, transform);
        newCard.Setup(chara, cardInfo);
        cards.Add(newCard);
        Display();
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
        Display();
    }

    private void Display()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = GetHandPosition(i, cards.Count);
        }
    }

    private Vector3 GetHandPosition(int index, int size)
    {
        float positionOffset = index - ((float)size - 1) / 2;
        var offset = Mathf.Sin(positionOffset * Mathf.Deg2Rad) * SPACING * 10;
        return new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
