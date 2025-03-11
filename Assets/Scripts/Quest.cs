using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public CardInfo questCardInfo;
    public int requirement;
    private int count = 0;

    public void Condition(CardInfo cardInfoToCheck)
    {
        if (cardInfoToCheck != questCardInfo)
        {
            return;
        }

        count++;

        if (count == requirement)
        {
            Debug.Log($"Quest is completed.");
        }
    }
}
