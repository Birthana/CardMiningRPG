using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        foreach (var quest in quests)
        {
            character.AddToOnMine(quest.Condition);
        }
    }

    public void Add(Quest quest)
    {
        quests.Add(quest);
        character.AddToOnMine(quest.Condition);
    }
}
