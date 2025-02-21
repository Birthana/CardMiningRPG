using UnityEngine;

public class CardInfo : ScriptableObject
{
    private Character character;

    public void SetCharacter(Character chara) { character = chara; }

    public Character GetCharacter() { return character; }

    protected bool IsInRange(Vector3 currentPosition, Vector3 movePosition, int range)
    {
        var distance = (currentPosition - movePosition).magnitude;
        return distance <= range;
    }
}
