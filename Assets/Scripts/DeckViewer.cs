using System.Collections.Generic;
using UnityEngine;

public class DeckViewer : MonoBehaviour
{
    public int MAX_DECK_SIZE = 15;
    public DeckCardUI deckCardUI;
    public Sprite emptySpace;
    public Deck deck;
    public Drop drop;
    public Hand hand;
    private List<DeckCardUI> uis = new List<DeckCardUI>();
    private bool isShown = false;

    public void Toggle()
    {
        if (isShown)
        {
            Clear();
            isShown = false;
            return;
        }

        View();
    }

    private void View()
    {
        Clear();
        SpawnUI(deck.Get());
        SpawnUI(hand.Get());
        SpawnUI(drop.Get());
        SpawnEmptySpace(MAX_DECK_SIZE - uis.Count);
        isShown = true;
    }

    private void SpawnUI(List<CardInfo> cardsToSpawn)
    {
        foreach (var card in cardsToSpawn)
        {
            var newCardUI = Instantiate(deckCardUI, transform);
            newCardUI.Setup(card.GetSprite());
            uis.Add(newCardUI);
        }
    }

    private void SpawnEmptySpace(int spaces)
    {
        for (int i = 0; i < spaces; i++)
        {
            var newCardUI = Instantiate(deckCardUI, transform);
            newCardUI.Setup(emptySpace);
            uis.Add(newCardUI);
        }
    }

    private void Clear()
    {
        foreach(var ui in uis)
        {
            Destroy(ui.gameObject);
        }

        uis = new List<DeckCardUI>();
    }
}
