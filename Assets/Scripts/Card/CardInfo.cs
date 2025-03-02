using UnityEngine;

public class CardInfo : ScriptableObject
{
    private Character character;

    public void SetCharacter(Character chara) { character = chara; }

    public Character GetCharacter() { return character; }
}
