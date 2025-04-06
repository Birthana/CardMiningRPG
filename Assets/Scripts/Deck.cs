using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int shuffleEnergyCost;
    public List<CardInfo> cardsToAdd = new List<CardInfo>();
    private List<CardInfo> cards = new List<CardInfo>();
    private Character character;
    private Drop drop;
    private int currentShuffleEnergyCost;

    private void Awake()
    {
        AddCardsToDeck();
        drop = FindObjectOfType<Drop>();
        currentShuffleEnergyCost = shuffleEnergyCost;
        Shuffle();
    }

    private void AddCardsToDeck()
    {
        foreach (var card in cardsToAdd)
        {
            var newCard = Instantiate(card);
            cards.Add(newCard);
        }
    }

    public void SetCharacter(Character newCharacter)
    {
        character = newCharacter;
    }

    public List<CardInfo> Get() { return cards; }

    public CardInfo Draw()
    {
        if (cards.Count == 0)
        {
            character.DecreaseEnergy(currentShuffleEnergyCost);
            currentShuffleEnergyCost += shuffleEnergyCost;
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
