using UnityEngine;

public class Rock : MonoBehaviour, IMineable
{
    public Item itemInfo;

    public void Mine(Character character)
    {
        FindObjectOfType<Hand>().Add(character, itemInfo);
    }
}
