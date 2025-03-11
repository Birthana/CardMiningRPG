using UnityEngine;

public class Rock : MonoBehaviour, IMineable
{
    public Item itemInfo;

    public CardInfo Mine(Character character)
    {
        FindObjectOfType<Hand>().Add(character, itemInfo);
        return itemInfo;
    }
}
