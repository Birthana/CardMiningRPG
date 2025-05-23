using System;
using UnityEngine;

[Serializable]
public class CardInfo : ScriptableObject
{
    public string cardName;
    public Sprite sprite;
    private Character character;

    public Sprite GetSprite() { return sprite; }

    public void SetCharacter(Character chara) { character = chara; }

    public Character GetCharacter() { return character; }
}
