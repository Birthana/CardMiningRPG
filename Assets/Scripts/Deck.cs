using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int shuffleEnergyCost;
    public List<CardInfo> cards = new List<CardInfo>();
    private Character character;
    private Drop drop;

    private void Awake()
    {
        drop = FindObjectOfType<Drop>();
        Shuffle();
    }

    public void SetCharacter(Character newCharacter)
    {
        character = newCharacter;
    }

    public CardInfo Draw()
    {
        if (cards.Count == 0)
        {
            character.DecreaseEnergy(shuffleEnergyCost);
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

    private void Shuffle()
    {
        for (int index = 0; index < cards.Count - 1; index++)
        {
            int randomIndex = index + Random.Range(0, cards.Count - index);
            CardInfo randomCard = cards[randomIndex];
            cards[randomIndex] = cards[index];
            cards[index] = randomCard;
        }
    }
}
