using UnityEngine;

[CreateAssetMenu(fileName = "DualCard", menuName = "CardInfo/DualCard")]
public class DualCard : CardInfo, IActionCard
{
    public int energyCost;
    public CardInfo cardInfo1;
    public CardInfo cardInfo2;

    public int GetEnergy() { return energyCost; }

    public bool CanPlay(Mouse mouse, Ground ground, RangeIndicator rangeIndicator)
    {
        return true;
    }

    public void Action(Mouse mouse, Ground ground)
    {
        var dualCardUI = FindObjectOfType<DualCardManager>();
        dualCardUI.Show(this);
    }
}
