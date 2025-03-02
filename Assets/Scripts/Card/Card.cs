using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]private CardInfo cardInfo;

    public void Setup(Character chara, CardInfo newCardInfo)
    {
        cardInfo = newCardInfo;
        cardInfo.SetCharacter(chara);
    }

    public CardInfo GetInfo() { return cardInfo; }

    public void Action(Mouse mouse, Ground ground)
    {
        if (cardInfo is not IActionCard)
        {
            return;
        }

        var action = (IActionCard)cardInfo;
        action.Action(mouse, ground);
    }
}
