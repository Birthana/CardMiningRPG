using System;
using UnityEngine;

[Serializable]
public class Card
{
    private CardInfo cardInfo;
    private CardUI ui;

    public Card(Character chara, CardInfo newCardInfo, CardUI cardUI)
    {
        cardInfo = newCardInfo;
        cardInfo.SetCharacter(chara);
        ui = cardUI;
        ui.Setup(cardInfo);
    }

    public CardInfo GetInfo() { return cardInfo; }

    public CardUI GetUI() { return ui; }

    public Vector3 GetUIPosition() { return ui.transform.position; }

    public void SetUIPosition(Vector3 position) { ui.transform.position = position; }

    public bool IsIn(Transform parent) { return ui.transform.parent == parent; }

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
