using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public CardUI cardUIPrefab;

    public Card Spawn(Character chara, CardInfo cardInfo, Transform parent)
    {
        var newCardUI = Instantiate(cardUIPrefab, parent);
        var newCardInfo = Instantiate(cardInfo);
        var newCard = new Card(chara, newCardInfo, newCardUI);
        return newCard;
    }
}
