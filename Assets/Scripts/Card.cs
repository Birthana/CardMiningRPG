using UnityEngine;

public class Card : MonoBehaviour
{
    public CardInfo cardInfo;
    private Mouse mouse;
    private Ground ground;

    private void Awake()
    {
        mouse = new Mouse(Camera.main);
        ground = FindObjectOfType<Ground>();
    }

    public void SetCharacter(Character chara) { cardInfo.SetCharacter(chara); }

    public void Action()
    {
        if (cardInfo is not IActionCard)
        {
            return;
        }

        var action = (IActionCard)cardInfo;
        action.Action(mouse, ground);
    }
}
