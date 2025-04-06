using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "CardInfo/Item")]
public class Item : CardInfo, IItemCard
{
    private int count = 1;

    public void AddToStack()
    {
        count++;
    }

    public int GetStackSize() { return count; }
}
