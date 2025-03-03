using UnityEngine;

public class CardInfo : ScriptableObject
{
    public Sprite sprite;
    private Character character;

    public Sprite GetSprite() { return sprite; }

    public void SetCharacter(Character chara) { character = chara; }

    public Character GetCharacter() { return character; }
}
